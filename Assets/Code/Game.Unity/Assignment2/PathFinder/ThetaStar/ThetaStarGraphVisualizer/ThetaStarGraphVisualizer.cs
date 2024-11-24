using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2.ThetaStarGraphVisualizer
{
    public class ThetaStarGraphVisualizer : MonoBehaviour
    {
        private Queue<IThetaStarNode> _nodesToVisit;
        private List<IThetaStarNode> _visitedNodes;
        private IThetaStarNode _startNode;
        private bool _isInitialized;
        
        public void Initialize(IThetaStarNode startNode)
        {
            _isInitialized = true;
            _nodesToVisit = new Queue<IThetaStarNode>(128);
            _visitedNodes = new List<IThetaStarNode>(128);
        }

        private void OnDrawGizmos()
        {
            if (_isInitialized == false)
            {
                return;
            }
            
            _nodesToVisit.Enqueue(_startNode);
            
            while (_nodesToVisit.Count > 0)
            {
                var currentNode = _nodesToVisit.Dequeue();
                _visitedNodes.Add(currentNode);
                
                var position = currentNode.Position;
                Gizmos.DrawSphere(position, 0.5f);
                
                foreach (var neighbour in currentNode.Neighbours)
                {
                    if (_visitedNodes.Contains(neighbour))
                    {
                        continue;
                    }
                    
                    _nodesToVisit.Enqueue(neighbour);
                    Gizmos.DrawLine(position, neighbour.Position);
                }
            }
            
            _nodesToVisit.Clear();
            _visitedNodes.Clear();
        }
    }
}
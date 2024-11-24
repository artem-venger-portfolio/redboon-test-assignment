using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarGraphVisualizer : MonoBehaviour
    {
        [SerializeField]
        private float _nodeRadius = 0.01f;

        private Queue<IThetaStarNode> _nodesToVisit;
        private List<IThetaStarNode> _visitedNodes;
        private IThetaStarNode _startNode;
        private bool _isInitialized;

        public void Initialize(IThetaStarNode startNode)
        {
            _isInitialized = true;
            _nodesToVisit = new Queue<IThetaStarNode>(capacity: 128);
            _visitedNodes = new List<IThetaStarNode>(capacity: 128);
            _startNode = startNode;
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
                Gizmos.DrawSphere(position, _nodeRadius);

                foreach (var neighbour in currentNode.Neighbours)
                {
                    if (_visitedNodes.Contains(neighbour))
                    {
                        continue;
                    }

                    if (_nodesToVisit.Contains(neighbour) == false)
                    {
                        _nodesToVisit.Enqueue(neighbour);
                    }

                    Gizmos.DrawLine(position, neighbour.Position);
                }
            }

            _nodesToVisit.Clear();
            _visitedNodes.Clear();
        }
    }
}
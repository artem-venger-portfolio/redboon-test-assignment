using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarRectangle : IThetaStarRectangle
    {
        private readonly Rectangle _originalRectangle;
        private readonly List<Passage> _passages;

        public ThetaStarRectangle(Rectangle originalRectangle, Passage passages, IThetaStarNode[,] nodes)
        {
            _originalRectangle = originalRectangle;
            _passages = new List<Passage> { passages };
            Nodes = nodes;
        }

        public IThetaStarNode[,] Nodes { get; }

        public bool Equals(Rectangle other)
        {
            return other == _originalRectangle;
        }

        public IThetaStarNode FindClosestNode(Vector2 position)
        {
            var closestNode = Nodes[0, 0];
            var closestDistance = Vector2.Distance(position, closestNode.Position);

            foreach (var node in Nodes)
            {
                var distance = Vector2.Distance(position, node.Position);
                if (distance >= closestDistance)
                {
                    continue;
                }

                closestNode = node;
                closestDistance = distance;
            }

            return closestNode;
        }

        public void AddPassage(Passage passage)
        {
            _passages.Add(passage);
        }
    }
}
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

        public bool IsIntersecting(Vector2 start, Vector2 end)
        {
            var isStartInside = IsInside(start);
            var isEndInside = IsInside(end);

            if ((isStartInside && isEndInside) ||
                (isStartInside == false && isEndInside == false))
            {
                return false;
            }

            var isIntersectingPassage = false;
            foreach (var currentPassage in _passages)
            {
                var isIntersecting = AreIntersecting(start, end, currentPassage.Start, currentPassage.End);
                if (isIntersecting == false)
                {
                    continue;
                }

                isIntersectingPassage = true;
                break;
            }

            return !isIntersectingPassage;
        }

        private bool IsInside(Vector2 point)
        {
            var min = _originalRectangle.Min;
            var max = _originalRectangle.Max;

            return min.x <= point.x && point.x <= max.x &&
                   min.y <= point.y && point.y <= max.y;
        }

        private static bool AreIntersecting(Vector2 line1Start, Vector2 line1End,
                                            Vector2 line2Start, Vector2 line2End)
        {
            return Geometry.AreIntersecting(line1Start, line1End, line2Start, line2End);
        }
    }
}
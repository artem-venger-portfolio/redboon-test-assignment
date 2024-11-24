using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStartLevel : IThetaStartLevel
    {
        private readonly IThetaStarRectangleFactory _rectangleFactory;
        private readonly List<IThetaStarRectangle> _rectangles;
        private readonly IThetaStarNodeFactory _nodeFactory;

        public ThetaStartLevel(IThetaStarRectangleFactory rectangleFactory, IThetaStarNodeFactory nodeFactory)
        {
            _rectangleFactory = rectangleFactory;
            _nodeFactory = nodeFactory;
            _rectangles = new List<IThetaStarRectangle>(capacity: 8);
        }

        public IThetaStarNode Start { get; private set; }

        public IThetaStarNode End { get; private set; }

        public bool Contains(Rectangle rectangle)
        {
            return _rectangles.Exists(r => r.Equals(rectangle));
        }

        public void Add(Edge edge)
        {
            var containsFirst = Contains(edge.First);
            var containsSecond = Contains(edge.Second);

            var containsAll = containsFirst && containsSecond;
            if (containsAll)
            {
                return;
            }

            var containsNone = containsFirst == false &&
                               containsSecond == false;
            if (containsNone)
            {
                _rectangleFactory.Create(edge, out var firstRectangle, out var secondRectangle);
                AddRectangle(firstRectangle);
                AddRectangle(secondRectangle);
                return;
            }

            if (containsFirst)
            {
                AddOneRectangle(edge, edge.First, edge.Second);
            }
            else
            {
                AddOneRectangle(edge, edge.Second, edge.First);
            }
        }

        public void AddStartAndEnd(Vector2 start, Vector2 end)
        {
            Start = AddNode(start, rectangleIndex: 0);
            End = AddNode(end, _rectangles.Count - 1);
        }

        public bool IsIntersecting(Vector2 start, Vector2 end)
        {
            foreach (var currentRectangle in _rectangles)
            {
                if (currentRectangle.IsIntersecting(start, end) == false)
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        private IThetaStarNode AddNode(Vector2 position, int rectangleIndex)
        {
            var node = _nodeFactory.Create(position);
            var closestNode = _rectangles[rectangleIndex].FindClosestNode(position);

            closestNode.AddNeighbour(node);
            node.AddNeighbour(closestNode);

            return node;
        }

        private void AddOneRectangle(Edge edge, Rectangle existingRectangle, Rectangle newRectangle)
        {
            var existingThetaStarRectangle = _rectangles.First(r => r.Equals(existingRectangle));
            var newThetaStarRectangle = _rectangleFactory.CreateSecond(existingThetaStarRectangle, newRectangle,
                                                                       edge.Start, edge.End);
            AddRectangle(newThetaStarRectangle);
        }

        private void AddRectangle(IThetaStarRectangle rectangle)
        {
            _rectangles.Add(rectangle);
        }
    }
}
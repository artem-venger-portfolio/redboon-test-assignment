using System.Collections.Generic;
using System.Linq;

namespace Game.Unity.Assignment2
{
    public class ThetaStartLevel : IThetaStartLevel
    {
        private readonly IThetaStarRectangleFactory _rectangleFactory;
        private readonly List<IThetaStarRectangle> _rectangles;

        public ThetaStartLevel(IThetaStarRectangleFactory rectangleFactory)
        {
            _rectangleFactory = rectangleFactory;
            _rectangles = new List<IThetaStarRectangle>(capacity: 8);
        }

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
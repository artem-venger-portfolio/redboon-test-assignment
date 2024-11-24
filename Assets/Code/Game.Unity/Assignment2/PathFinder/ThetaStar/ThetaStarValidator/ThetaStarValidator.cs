using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarValidator : IThetaStarValidator
    {
        private readonly IGameLogger _logger;

        public ThetaStarValidator(IGameLogger logger)
        {
            _logger = logger;
        }

        public bool Validate(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            var isStartPointValid = ValidatePoint(start, edges);
            var isEndPointValid = ValidatePoint(end, edges);

            return isStartPointValid && isEndPointValid;
        }

        private bool ValidatePoint(Vector2 point, IEnumerable<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (IsInside(edge.First, point) || IsInside(edge.Second, point))
                {
                    return true;
                }
            }

            LogError($"Point {point} is not inside any of the rectangles.");

            return false;
        }

        private static bool IsInside(Rectangle rectangle, Vector2 point)
        {
            var min = rectangle.Min;
            var max = rectangle.Max;

            return min.x <= point.x && point.x <= max.x &&
                   min.y <= point.y && point.y <= max.y;
        }

        private void LogError(string message)
        {
            _logger.LogError($"[Validation] {message}");
        }
    }
}
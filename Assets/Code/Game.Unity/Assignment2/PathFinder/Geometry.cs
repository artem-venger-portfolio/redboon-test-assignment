using System;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public static class Geometry
    {
        public static bool AreIntersecting(Vector2 line1Start, Vector2 line1End, 
                                           Vector2 line2Start, Vector2 line2End)
        {
            var vector1 = line1End - line1Start;
            var vector2 = line2End - line2Start;
            
            var denominator = (-vector2.x * vector1.y + vector1.x * vector2.y);
            
            if (line1Start == line2Start || line1Start == line2End ||
                line1End == line2Start || line1End == line2End)
            {
                return true;
            }

            if (Mathf.Approximately(denominator, 0))
            {
                throw new InvalidOperationException("Cannot calculate intersection of parallel lines");
            }
            
            var s = (-vector1.y * (line1Start.x - line2Start.x) + vector1.x * (line1Start.y - line2Start.y)) / 
                    denominator;
            var t = (vector2.x * (line1Start.y - line2Start.y) - vector2.y * (line1Start.x - line2Start.x)) / 
                    denominator;

            return s >= 0 && s <= 1 && t >= 0 && t <= 1;
        }
    }
}
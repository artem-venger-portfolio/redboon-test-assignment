using UnityEngine;

namespace Game.Unity.Assignment2
{
    public struct Rectangle
    {
        public Vector2 Min;
        public Vector2 Max;

        public Rectangle(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }
    }
}
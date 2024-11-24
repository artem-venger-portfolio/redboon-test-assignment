using UnityEngine;

namespace Game.Unity.Assignment2
{
    public readonly struct Passage
    {
        public Vector2 Start { get; }
        public Vector2 End { get; }

        public Passage(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }
    }
}
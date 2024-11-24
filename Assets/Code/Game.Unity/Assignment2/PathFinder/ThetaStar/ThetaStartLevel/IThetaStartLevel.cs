using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStartLevel
    {
        IThetaStarNode Start { get; }
        IThetaStarNode End { get; }
        bool Contains(Rectangle rectangle);
        void Add(Edge edge);
        void AddStartAndEnd(Vector2 start, Vector2 end);
    }
}
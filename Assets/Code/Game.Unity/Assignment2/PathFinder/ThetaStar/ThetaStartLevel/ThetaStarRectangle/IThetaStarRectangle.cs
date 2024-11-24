using System;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarRectangle : IEquatable<Rectangle>
    {
        IThetaStarNode[,] Nodes { get; }
        IThetaStarNode FindClosestNode(Vector2 position);
        void AddPassage(Passage passage);
        bool IsIntersecting(Vector2 start, Vector2 end);
    }
}
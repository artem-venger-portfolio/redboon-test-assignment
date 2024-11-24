using System;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarRectangle : IEquatable<Rectangle>
    {
        IThetaStarNode[,] Nodes { get; }
        IThetaStarNode FindClosestNode(Vector2 position);
    }
}
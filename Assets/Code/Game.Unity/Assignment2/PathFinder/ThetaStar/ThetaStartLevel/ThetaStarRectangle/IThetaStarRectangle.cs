using System;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarRectangle : IEquatable<Rectangle>
    {
        IThetaStarNode[,] Nodes { get; }
    }
}
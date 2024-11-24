using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarNode
    {
        Vector2 Position { get; }
        IReadOnlyList<IThetaStarNode> Neighbours { get; }
        IThetaStarNode Parent { get; set; }
        float Score { get; set; }
        void AddNeighbour(IThetaStarNode neighbor);
    }
}
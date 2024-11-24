using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarNode : IThetaStarNode
    {
        private readonly List<IThetaStarNode> _neighbours;

        public ThetaStarNode(Vector2 position)
        {
            Position = position;
            _neighbours = new List<IThetaStarNode>(capacity: 4);
            Score = float.MaxValue;
        }

        public Vector2 Position { get; }
        public IThetaStarNode Parent { get; set; }
        public float Score { get; set; }

        public IReadOnlyList<IThetaStarNode> Neighbours => _neighbours;

        public void AddNeighbour(IThetaStarNode neighbor)
        {
            _neighbours.Add(neighbor);
        }
    }
}
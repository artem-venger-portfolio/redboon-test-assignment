using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarNodeFactory : IThetaStarNodeFactory
    {
        public IThetaStarNode Create(Vector2 position)
        {
            return new ThetaStarNode(position);
        }
    }
}
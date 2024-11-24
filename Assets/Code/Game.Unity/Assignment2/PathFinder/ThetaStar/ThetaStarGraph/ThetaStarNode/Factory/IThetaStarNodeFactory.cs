using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarNodeFactory
    {
        IThetaStarNode Create(Vector2 position);
    }
}
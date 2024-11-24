using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarRectangleFactory
    {
        void Create(Edge edge, out IThetaStarRectangle firstRectangle, out IThetaStarRectangle secondRectangle);

        IThetaStarRectangle CreateSecond(IThetaStarRectangle firstRectangle, Rectangle secondRectangle,
                                         Vector2 passageStart, Vector2 passageEnd);
    }
}
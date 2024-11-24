using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public interface IThetaStarValidator
    {
        bool Validate(Vector2 start, Vector2 end, IEnumerable<Edge> edges);
    }
}
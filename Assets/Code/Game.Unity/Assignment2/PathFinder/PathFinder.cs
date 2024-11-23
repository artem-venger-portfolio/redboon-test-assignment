using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            return new List<Vector2>
            {
                start,
                end
            };
        }
    }
}
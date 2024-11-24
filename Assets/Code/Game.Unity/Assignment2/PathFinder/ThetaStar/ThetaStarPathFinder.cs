using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarPathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            IThetaStarNodeFactory nodeFactory = new ThetaStarNodeFactory();
            IThetaStarRectangleFactory rectangleFactory = new ThetaStarRectangleFactory(nodeFactory);
            IThetaStartLevel level = new ThetaStartLevel(rectangleFactory);

            foreach (var currentEdge in edges)
            {
                level.Add(currentEdge);
            }

            var visualizerGO = new GameObject(nameof(ThetaStarGraphVisualizer));
            var visualizer = visualizerGO.AddComponent<ThetaStarGraphVisualizer>();
            var startNode = level.Start;
            visualizer.Initialize(startNode);

            return new List<Vector2> { start, end };
        }
    }
}
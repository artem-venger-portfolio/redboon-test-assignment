using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarPathFinder : IPathFinder
    {
        private readonly Queue<IThetaStarNode> _open = new Queue<IThetaStarNode>(capacity: 128);
        private readonly List<IThetaStarNode> _closed = new List<IThetaStarNode>(capacity: 128);

        public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            IThetaStarNodeFactory nodeFactory = new ThetaStarNodeFactory();
            IThetaStarRectangleFactory rectangleFactory = new ThetaStarRectangleFactory(nodeFactory);
            IThetaStartLevel level = new ThetaStartLevel(rectangleFactory, nodeFactory);

            foreach (var currentEdge in edges)
            {
                level.Add(currentEdge);
            }

            level.AddStartAndEnd(start, end);

            var visualizerGO = new GameObject(nameof(ThetaStarGraphVisualizer));
            var visualizer = visualizerGO.AddComponent<ThetaStarGraphVisualizer>();
            var startNode = level.Start;
            visualizer.Initialize(startNode);

            var path = FindPath(startNode, level.End);

            return path;
        }

        private IEnumerable<Vector2> FindPath(IThetaStarNode starNode, IThetaStarNode endNode)
        {
            _open.Enqueue(starNode);
            starNode.Score = 0;

            while (_open.Count > 0)
            {
                var currentNode = _open.Dequeue();
                if (currentNode == endNode)
                {
                    return ReconstructPath(currentNode);
                }

                _closed.Add(currentNode);

                foreach (var currentNeighbour in currentNode.Neighbours)
                {
                    if (_closed.Contains(currentNeighbour))
                    {
                        continue;
                    }

                    UpdateNeighbour(currentNode, currentNeighbour);
                }
            }

            return new List<Vector2>();
        }

        private void UpdateNeighbour(IThetaStarNode currentNode, IThetaStarNode neighbour)
        {
            var newNeighbourScore = currentNode.Score + GetDistance(currentNode, neighbour);
            if (newNeighbourScore >= neighbour.Score)
            {
                return;
            }

            neighbour.Score = newNeighbourScore;
            neighbour.Parent = currentNode;

            if (_open.Contains(neighbour) == false)
            {
                _open.Enqueue(neighbour);
            }
        }

        private float GetDistance(IThetaStarNode currentNode, IThetaStarNode neighbour)
        {
            return Vector2.Distance(currentNode.Position, neighbour.Position);
        }

        private static IEnumerable<Vector2> ReconstructPath(IThetaStarNode end)
        {
            var path = new List<Vector2>();
            var currentNode = end;
            while (currentNode.Parent != null)
            {
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return path;
        }
    }
}
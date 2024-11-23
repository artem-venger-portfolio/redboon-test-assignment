using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            var edges = new List<Edge>
            {
                new Edge(
                    new Rectangle(new Vector2(x: -15, y: 15), new Vector2(x: 2, y: 25)),
                    new Rectangle(new Vector2(x: -3, y: 25), new Vector2(x: 17, y: 35)),
                    new Vector2(x: -3, y: 25),
                    new Vector2(x: -2, y: 25)
                ),
                new Edge(
                    new Rectangle(new Vector2(x: -3, y: 25), new Vector2(x: 17, y: 35)),
                    new Rectangle(new Vector2(x: 17, y: 20), new Vector2(x: 37, y: 30)),
                    new Vector2(x: 17, y: 25),
                    new Vector2(x: 17, y: 30)
                )
            };

            IPathFinder pathFinder = new PathFinder();
            var result = pathFinder.GetPath(new Vector2(x: -6.5f, y: 15),
                                            new Vector2(x: 37, y: 25),
                                            edges);
        }
    }
}
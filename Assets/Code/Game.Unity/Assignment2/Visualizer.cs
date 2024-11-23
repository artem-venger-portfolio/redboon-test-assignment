using System.Collections.Generic;
using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class Visualizer
    {
        private IEnumerable<Vector2> _path;
        private readonly IList<Edge> _edges;
        private int _rectangleIndex;

        public Visualizer(IEnumerable<Vector2> path, IList<Edge> edges)
        {
            _path = path;
            _edges = edges;
        }

        public void Draw()
        {
            var unitSprite = CreateSprite(Color.white);
            var lineMaterial = new Material(Shader.Find(name: "Legacy Shaders/Particles/Alpha Blended Premultiply"));

            for (var i = 0; i < _edges.Count; i++)
            {
                var currentEdge = _edges[i];
                var currentFirstRect = currentEdge.First;
                var currentSecondRect = currentEdge.Second;

                DrawLine($"Passage {i}", currentEdge.Start, currentEdge.End, Color.red, lineMaterial);

                if (i == 0)
                {
                    DrawRect(currentFirstRect, unitSprite);
                    DrawRect(currentSecondRect, unitSprite);
                    continue;
                }

                var previousEdge = _edges[i - 1];
                var previousFirstRect = previousEdge.First;
                var previousSecondRect = previousEdge.Second;

                if (currentFirstRect != previousFirstRect &&
                    currentFirstRect != previousSecondRect)
                {
                    DrawRect(currentFirstRect, unitSprite);
                }

                if (currentSecondRect != previousFirstRect &&
                    currentSecondRect != previousSecondRect)
                {
                    DrawRect(currentSecondRect, unitSprite);
                }
            }
        }

        private static Sprite CreateSprite(Color color)
        {
            var texture = new Texture2D(width: 1, height: 1);
            texture.SetPixel(x: 0, y: 0, color);
            texture.wrapMode = TextureWrapMode.Repeat;
            texture.Apply();

            var spriteRect = new Rect(x: 0, y: 0, width: 1, height: 1);
            var pivot = Vector2.zero;
            var sprite = Sprite.Create(texture, spriteRect, pivot, pixelsPerUnit: 1, extrude: 0,
                                       SpriteMeshType.FullRect);

            return sprite;
        }

        private void DrawRect(Rectangle rectangle, Sprite sprite)
        {
            var rectangleMin = rectangle.Min;
            var rectangleMax = rectangle.Max;
            var size = new Vector2(rectangleMax.x - rectangleMin.x, rectangleMax.y - rectangleMin.y);

            var rectangleSpriteGO = new GameObject($"Rectangle {_rectangleIndex++}");

            var rectangleSprite = rectangleSpriteGO.AddComponent<SpriteRenderer>();
            rectangleSprite.sprite = sprite;
            rectangleSprite.drawMode = SpriteDrawMode.Tiled;
            rectangleSprite.size = size;
            rectangleSprite.color = Color.gray;

            var rectangleSpriteTransform = rectangleSpriteGO.transform;
            rectangleSpriteTransform.position = rectangleMin;
        }

        private void DrawLine(string name, Vector2 start, Vector2 end, Color color, Material material)
        {
            var lineRendererGO = new GameObject(name);
            var lineRenderer = lineRendererGO.AddComponent<LineRenderer>();
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.SetPosition(index: 0, start);
            lineRenderer.SetPosition(index: 1, end);
            lineRenderer.sharedMaterial = material;
        }
    }
}
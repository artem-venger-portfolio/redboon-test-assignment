using UnityEngine;

namespace Game.Unity.Assignment2
{
    public class ThetaStarRectangleFactory : IThetaStarRectangleFactory
    {
        private readonly IThetaStarNodeFactory _nodeFactory;

        public ThetaStarRectangleFactory(IThetaStarNodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        public void Create(Edge edge, out IThetaStarRectangle firstRectangle, out IThetaStarRectangle secondRectangle)
        {
            var linkNode = CreateLinkNode(edge.Start, edge.End);

            firstRectangle = Create(edge.First, linkNode);
            secondRectangle = Create(edge.Second, linkNode);
        }

        public IThetaStarRectangle CreateSecond(IThetaStarRectangle firstRectangle, Rectangle secondRectangle,
                                                Vector2 passageStart, Vector2 passageEnd)
        {
            var linkNode = CreateLinkNode(passageStart, passageEnd);
            ConnectWithLinkNode(firstRectangle, linkNode);
            var secondThetaStarRectangle = Create(secondRectangle, linkNode);

            return secondThetaStarRectangle;
        }

        private IThetaStarNode CreateLinkNode(Vector2 passageStart, Vector2 passageEnd)
        {
            var passageCenter = (passageStart + passageEnd) / 2;
            var linkNode = CreateNode(passageCenter);

            return linkNode;
        }

        private IThetaStarRectangle Create(Rectangle rectangle, IThetaStarNode linkNode)
        {
            var nodes = CreateNodes(rectangle);
            var thetaStarRectangle = new ThetaStarRectangle(rectangle, nodes);
            ConnectWithLinkNode(thetaStarRectangle, linkNode);

            return thetaStarRectangle;
        }

        private static void ConnectWithLinkNode(IThetaStarRectangle rectangle, IThetaStarNode linkNode)
        {
            var closestNode = FindClosestNode(linkNode.Position, rectangle.Nodes);

            closestNode.AddNeighbour(linkNode);
            linkNode.AddNeighbour(closestNode);
        }

        private IThetaStarNode[,] CreateNodes(Rectangle rectangle)
        {
            var min = rectangle.Min;
            var minX = min.x;
            var minY = min.y;
            var max = rectangle.Max;
            var maxX = max.x;
            var maxY = max.y;

            var startX = ToIntGrid(minX, minX, maxX);
            var finishX = ToIntGrid(maxX, minX, maxX);
            var startY = ToIntGrid(minY, minY, maxY);
            var finishY = ToIntGrid(maxY, minY, maxY);

            var xSize = finishX - startX + 1;
            var ySize = finishY - startY + 1;

            var nodes = new IThetaStarNode[xSize, ySize];
            for (int x = startX, i = 0; x <= finishX; x++, i++)
            {
                for (int y = startY, j = 0; y <= finishY; y++, j++)
                {
                    var node = CreateNode(new Vector2(x, y));
                    nodes[i, j] = node;

                    var hasLeftNeighbour = i > 0;
                    if (hasLeftNeighbour)
                    {
                        var leftNeighbour = nodes[i - 1, j];
                        node.AddNeighbour(leftNeighbour);
                        leftNeighbour.AddNeighbour(node);
                    }

                    var hasBottomNeighbour = j > 0;
                    if (hasBottomNeighbour)
                    {
                        var bottomNeighbour = nodes[i, j - 1];
                        node.AddNeighbour(bottomNeighbour);
                        bottomNeighbour.AddNeighbour(node);
                    }
                }
            }

            return nodes;
        }

        private static int ToIntGrid(float value, float min, float max)
        {
            var intValue = (int)value;
            if (intValue < min)
            {
                intValue++;
            }
            else if (intValue > max)
            {
                intValue--;
            }

            return intValue;
        }

        private static IThetaStarNode FindClosestNode(Vector2 position, IThetaStarNode[,] nodes)
        {
            var closestNode = nodes[0, 0];
            var closestDistance = Vector2.Distance(position, closestNode.Position);

            foreach (var node in nodes)
            {
                var distance = Vector2.Distance(position, node.Position);
                if (distance >= closestDistance)
                {
                    continue;
                }

                closestNode = node;
                closestDistance = distance;
            }

            return closestNode;
        }

        private IThetaStarNode CreateNode(Vector2 position)
        {
            return _nodeFactory.Create(position);
        }
    }
}
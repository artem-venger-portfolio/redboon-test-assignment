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
            var max = rectangle.Max;

            var startX = (int)min.x;
            var finishX = (int)max.x;
            var startY = (int)min.y;
            var finishY = (int)max.y;

            var xSize = finishX - startX + 1;
            var ySize = finishY - startY + 1;

            var nodes = new IThetaStarNode[xSize, ySize];
            for (var x = startX; x <= finishX; x++)
            {
                for (var y = startY; y <= finishY; y++)
                {
                    var node = CreateNode(new Vector2(x, y));
                    nodes[x, y] = node;

                    var hasLeftNeighbour = x > startX;
                    if (hasLeftNeighbour)
                    {
                        var leftNeighbour = nodes[x - 1, y];
                        node.AddNeighbour(leftNeighbour);
                        leftNeighbour.AddNeighbour(node);
                    }

                    var hasBottomNeighbour = y > startY;
                    if (hasBottomNeighbour)
                    {
                        var bottomNeighbour = nodes[x, y - 1];
                        node.AddNeighbour(bottomNeighbour);
                        bottomNeighbour.AddNeighbour(node);
                    }
                }
            }

            return nodes;
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
namespace Game.Unity.Assignment2
{
    public class ThetaStarRectangle : IThetaStarRectangle
    {
        private readonly Rectangle _originalRectangle;

        public ThetaStarRectangle(Rectangle originalRectangle, IThetaStarNode[,] nodes)
        {
            _originalRectangle = originalRectangle;
            Nodes = nodes;
        }

        public IThetaStarNode[,] Nodes { get; }

        public bool Equals(Rectangle other)
        {
            return other == _originalRectangle;
        }
    }
}
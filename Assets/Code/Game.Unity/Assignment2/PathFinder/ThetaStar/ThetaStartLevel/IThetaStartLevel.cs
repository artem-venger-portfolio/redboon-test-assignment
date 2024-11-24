namespace Game.Unity.Assignment2
{
    public interface IThetaStartLevel
    {
        IThetaStarNode Start { get; }
        bool Contains(Rectangle rectangle);
        void Add(Edge edge);
    }
}
namespace Game.Common
{
    public interface IGameLogger
    {
        void Log(string message);
        void LogError(string message);
    }
}
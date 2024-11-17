using Game.Common;
using UnityEngine;

namespace Game.Unity.Common
{
    public class UnityLogger : IGameLogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}
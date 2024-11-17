using Game.Common;
using Game.Unity.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            IGameLogger logger = new UnityLogger();
            logger.Log(message: "Hello, World!");
        }
    }
}
using Game.Common;
using Game.Unity.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private ConfigSO _config;

        private void Awake()
        {
            IGameLogger logger = new UnityLogger();
            logger.Log(message: "Hello, World!");
        }
    }
}
using Game.Assignment1;
using UnityEngine;

namespace Game.Unity.Assignment1.HUD
{
    public abstract class HUDBase : MonoBehaviour
    {
        public abstract void Initialize(ICharacter character);
    }
}
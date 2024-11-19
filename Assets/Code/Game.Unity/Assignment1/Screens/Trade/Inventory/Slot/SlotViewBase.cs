using Game.Assignment1;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class SlotViewBase : MonoBehaviour
    {
        public abstract void Initialize(Items item, int count);
    }
}
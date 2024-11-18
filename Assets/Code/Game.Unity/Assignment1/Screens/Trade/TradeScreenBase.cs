using Game.Assignment1;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class TradeScreenBase : MonoBehaviour
    {
        public abstract void Initialize(ICharacter character, IMerchant merchant);
    }
}
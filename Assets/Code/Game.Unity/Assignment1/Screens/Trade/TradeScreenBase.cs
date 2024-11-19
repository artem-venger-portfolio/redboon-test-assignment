using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class TradeScreenBase : MonoBehaviour
    {
        public abstract void Initialize(ICharacter character, IMerchant merchant, SlotViewBase slotTemplate,
                                        IGameLogger logger);
    }
}
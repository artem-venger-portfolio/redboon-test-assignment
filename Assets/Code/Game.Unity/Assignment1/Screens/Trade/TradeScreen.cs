using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class TradeScreen : TradeScreenBase
    {
        [SerializeField]
        private InventoryViewBase _characterInventory;

        [SerializeField]
        private InventoryViewBase _merchantInventory;

        private ICharacter _character;
        private IMerchant _merchant;

        public override void Initialize(ICharacter character, IMerchant merchant, SlotViewBase slotTemplate,
                                        IGameLogger logger)
        {
            _character = character;
            _merchant = merchant;

            _characterInventory.Initialize(_character, slotTemplate, logger);
            _merchantInventory.Initialize(_merchant, slotTemplate, logger);
        }
    }
}
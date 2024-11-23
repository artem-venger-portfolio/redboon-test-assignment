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

        [SerializeField]
        private Transform _draggingObjectContainer;

        private ICharacter _character;
        private IGameLogger _logger;
        private IMerchant _merchant;

        public override void Initialize(ICharacter character, IMerchant merchant, SlotViewBase slotTemplate,
                                        IGameLogger logger)
        {
            _character = character;
            _merchant = merchant;
            _logger = logger;

            _characterInventory.Initialize(_character.Inventory, slotTemplate, _draggingObjectContainer, logger);
            _characterInventory.ItemDropped += CharacterItemDroppedEventHandler;

            _merchantInventory.Initialize(_merchant.Inventory, slotTemplate, _draggingObjectContainer, logger);
            _merchantInventory.ItemDropped += MerchantItemDroppedEventHandler;
        }

        private void CharacterItemDroppedEventHandler(Vector2 position)
        {
            LogInfo(nameof(CharacterItemDroppedEventHandler));
            if (_merchantInventory.IsWithinBounds(position))
            {
                LogInfo(message: "Character item dropped on merchant inventory");
            }
        }

        private void MerchantItemDroppedEventHandler(Vector2 position)
        {
            LogInfo(nameof(MerchantItemDroppedEventHandler));
            if (_characterInventory.IsWithinBounds(position))
            {
                LogInfo(message: "Merchant item dropped on character inventory");
            }
        }

        private void LogInfo(string message)
        {
            _logger.Log($"[{nameof(TradeScreen)}] {message}");
        }
    }
}
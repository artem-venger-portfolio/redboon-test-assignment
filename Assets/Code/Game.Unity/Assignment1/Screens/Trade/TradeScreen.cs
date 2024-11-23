using System.Collections.Generic;
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

            var characterSlotViewInfo = GetSlotViewInfo(_character.Inventory);
            _characterInventory.Initialize(characterSlotViewInfo, slotTemplate, _draggingObjectContainer, logger);
            _characterInventory.ItemDropped += CharacterItemDroppedEventHandler;

            var merchantSlotViewInfo = GetSlotViewInfo(_merchant.Inventory);
            _merchantInventory.Initialize(merchantSlotViewInfo, slotTemplate, _draggingObjectContainer, logger);
            _merchantInventory.ItemDropped += MerchantItemDroppedEventHandler;
        }

        private List<SlotViewInfo> GetSlotViewInfo(IInventory inventory)
        {
            var characterSlotViewInfo = new List<SlotViewInfo>();
            foreach (var currentItem in inventory.Items)
            {
                var price = inventory.GetPrice(currentItem);
                var slotViewInfo = new SlotViewInfo(currentItem, price);
                characterSlotViewInfo.Add(slotViewInfo);
            }

            return characterSlotViewInfo;
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
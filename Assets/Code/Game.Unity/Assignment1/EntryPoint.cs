using System.Collections.Generic;
using Game.Assignment1;
using Game.Common;
using Game.Unity.Assignment1.HUD;
using Game.Unity.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private ConfigSO _config;

        [SerializeField]
        private TradeScreenBase _tradeScreen;

        [SerializeField]
        private SlotViewBase _slotTemplate;

        [SerializeField]
        private HUDBase _hud;

        private void Awake()
        {
            IGameLogger logger = new UnityLogger();

            var characterInventory = CreateInventory(_config.CharacterInventory);
            ICharacter character = new Character(characterInventory, _config.CharacterMoney, logger);

            var merchantInventory = CreateInventory(_config.MerchantInventory);
            IMerchant merchant = new Merchant(merchantInventory, logger);

            _tradeScreen.Initialize(character, merchant, _slotTemplate, logger);
            _hud.Initialize(character);
        }

        private static IInventory CreateInventory(IList<SlotConfig> configCharacterInventory)
        {
            var inventory = new InventoryDefault();
            foreach (var slotData in configCharacterInventory)
            {
                var slot = new SlotDefault(slotData.Item, slotData.Quantity);
                inventory.Add(slot);
            }

            return inventory;
        }
    }
}
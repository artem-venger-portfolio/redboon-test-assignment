using System.Collections.Generic;
using System.Linq;
using Game.Assignment1;
using Game.Assignment1.PriceController;
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

        private IPriceController _priceController;

        private void Awake()
        {
            IGameLogger logger = new UnityLogger();

            var prices = _config.Price.ToDictionary(currentPrice => currentPrice.Item, 
                                                    currentPrice => currentPrice.Price);
            _priceController = new PriceController(prices, _config.SellPriceMultiplier);

            var characterInventory = CreateInventory(_config.CharacterInventory);
            ICharacter character = new Character(characterInventory, _config.CharacterMoney, logger);

            var merchantInventory = CreateInventory(_config.MerchantInventory);
            IMerchant merchant = new Merchant(merchantInventory, logger);


            _tradeScreen.Initialize(character, merchant, _slotTemplate, logger);
            _hud.Initialize(character);
        }

        private static IInventory CreateInventory(IList<Items> configCharacterInventory)
        {
            var inventory = new InventoryDefault();
            foreach (var currentItem in configCharacterInventory)
            {
                inventory.Add(currentItem);
            }

            return inventory;
        }
    }
}
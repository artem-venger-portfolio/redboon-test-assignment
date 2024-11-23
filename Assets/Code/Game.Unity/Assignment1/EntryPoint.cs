using System.Collections.Generic;
using System.Linq;
using Game.Assignment1;
using Game.Common;
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
            var prices = _config.Price.ToDictionary(currentPrice => currentPrice.Item,
                                                    currentPrice => currentPrice.Price);

            var characterInventory = CreateInventory(_config.CharacterInventory, prices, _config.SellPriceMultiplier);
            ICharacter character = new Character(characterInventory, _config.CharacterMoney, logger);

            var merchantInventory = CreateInventory(_config.MerchantInventory, prices, priceMultiplier: 1f);
            IMerchant merchant = new Merchant(merchantInventory, logger);

            ITrade trade = new Trade(character, merchant);
            _tradeScreen.Initialize(trade, character, merchant, _slotTemplate, logger);
            _hud.Initialize(character);
        }

        private static IInventory CreateInventory(IList<Items> configCharacterInventory, Dictionary<Items, int> prices,
                                                  float priceMultiplier)
        {
            IPriceCalculator priceCalculator = new MultiplicativePriceCalculator(prices, priceMultiplier);
            IInventory inventory = new InventoryDefault(priceCalculator);
            foreach (var currentItem in configCharacterInventory)
            {
                inventory.Add(currentItem);
            }

            return inventory;
        }
    }
}
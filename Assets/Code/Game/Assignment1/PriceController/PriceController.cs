using System.Collections.Generic;

namespace Game.Assignment1.PriceController
{
    public class PriceController : IPriceController
    {
        private readonly Dictionary<Items, int> _prices;
        private readonly float _sellPriceMultiplier;

        public PriceController(Dictionary<Items, int> prices, float sellPriceMultiplier)
        {
            _prices = prices;
            _sellPriceMultiplier = sellPriceMultiplier;
        }

        public int GetPurchasePrice(Items item)
        {
            return _prices[item];
        }

        public int GetSellPrice(Items item)
        {
            return (int)(GetPurchasePrice(item) * _sellPriceMultiplier);
        }
    }
}
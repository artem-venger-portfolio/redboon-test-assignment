using System.Collections.Generic;

namespace Game.Assignment1.PriceCalculator
{
    public class MultiplicativePriceCalculator : IPriceCalculator
    {
        private readonly Dictionary<Items, int> _prices;
        private readonly float _multiplier;

        public MultiplicativePriceCalculator(Dictionary<Items, int> prices, float multiplier = 1)
        {
            _prices = prices;
            _multiplier = multiplier;
        }

        public int GetPrice(Items item)
        {
            var result = _prices[item] * _multiplier;
            var resultInt = (int)result;

            return resultInt;
        }
    }
}
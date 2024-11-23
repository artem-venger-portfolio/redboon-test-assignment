using System.Collections.Generic;
using Game.Assignment1.PriceCalculator;

namespace Game.Assignment1
{
    public class InventoryDefault : IInventory
    {
        private readonly List<Items> _items = new List<Items>();
        private readonly IPriceCalculator _priceCalculator;

        public InventoryDefault(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public IReadOnlyList<Items> Items => _items;

        public void Add(Items item)
        {
            _items.Add(item);
        }

        public int GetPrice(Items item)
        {
            return _priceCalculator.GetPrice(item);
        }
    }
}
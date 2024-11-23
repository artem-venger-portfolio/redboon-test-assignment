using System.Collections.Generic;

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

        public void Remove(Items item)
        {
            _items.Remove(item);
        }

        public int GetPrice(Items item)
        {
            return _priceCalculator.GetPrice(item);
        }

        public bool HasItem(Items item)
        {
            return _items.Contains(item);
        }
    }
}
using System;
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

        public event Action<Items, InventoryOperation> Changed;

        public void Add(Items item)
        {
            _items.Add(item);
            Changed?.Invoke(item, InventoryOperation.Add);
        }

        public void Remove(Items item)
        {
            _items.Remove(item);
            Changed?.Invoke(item, InventoryOperation.Remove);
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
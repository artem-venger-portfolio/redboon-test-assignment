using System.Collections.Generic;

namespace Game.Assignment1
{
    public class InventoryDefault : IInventory
    {
        private readonly List<Items> _items = new List<Items>();

        public IReadOnlyList<Items> Items => _items;

        public void Add(Items item)
        {
            _items.Add(item);
        }
    }
}
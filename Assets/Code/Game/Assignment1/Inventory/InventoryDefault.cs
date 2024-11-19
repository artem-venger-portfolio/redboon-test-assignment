using System.Collections.Generic;
using System.Linq;

namespace Game.Assignment1
{
    public class InventoryDefault : IInventory
    {
        private readonly List<ISlot> _slots = new List<ISlot>();

        public IList<ItemToQuantity> GetItems()
        {
            var items = new List<ItemToQuantity>();

            foreach (var slot in _slots)
            {
                items.Add(new ItemToQuantity(slot.Item, slot.Quantity));
            }

            return items;
        }

        public void Add(ISlot slot)
        {
            var item = slot.Item;
            var quantity = slot.Quantity;
            if (HasItem(item))
            {
                var existingSlot = FindSlot(item);
                existingSlot.AddQuantity(quantity);
            }
            else
            {
                _slots.Add(slot);
            }
        }

        private bool HasItem(Items item)
        {
            return _slots.Any(slot => slot.Item == item);
        }

        private ISlot FindSlot(Items item)
        {
            return _slots.First(slot => slot.Item == item);
        }
    }
}
using System.Collections.Generic;

namespace Game.Assignment1
{
    public interface IInventory
    {
        IList<ItemToQuantity> GetItems();
        void Add(ISlot slot);
    }
}
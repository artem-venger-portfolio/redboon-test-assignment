using System;
using System.Collections.Generic;

namespace Game.Assignment1
{
    public interface IInventory
    {
        IReadOnlyList<Items> Items { get; }
        event Action<Items, InventoryOperation> Changed;
        void Add(Items item);
        void Remove(Items item);
        int GetPrice(Items item);
        bool HasItem(Items item);
    }
}
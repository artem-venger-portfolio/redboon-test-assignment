using System.Collections.Generic;

namespace Game.Assignment1
{
    public interface IInventory
    {
        IReadOnlyList<Items> Items { get; }
        void Add(Items item);
        int GetPrice(Items item);
        bool HasItem(Items item);
    }
}
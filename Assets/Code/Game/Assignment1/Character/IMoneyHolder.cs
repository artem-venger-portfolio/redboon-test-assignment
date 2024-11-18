using System;

namespace Game.Assignment1
{
    public interface IMoneyHolder
    {
        int Money { get; set; }
        event Action<int> MoneyChanged;
    }
}
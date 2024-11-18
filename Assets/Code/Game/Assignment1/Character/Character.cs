using System;
using Game.Common;

namespace Game.Assignment1
{
    public class Character : ICharacter
    {
        private readonly IGameLogger _logger;
        private int _money;

        public Character(IInventory inventory, int money, IGameLogger logger)
        {
            _logger = logger;
            Inventory = inventory;
            Money = money;
        }

        public IInventory Inventory { get; }

        public int Money
        {
            get => _money;
            set
            {
                var newValue = Math.Max(val1: 0, value);
                if (newValue == _money)
                {
                    return;
                }

                _money = newValue;
                MoneyChanged?.Invoke(_money);
            }
        }

        public event Action<int> MoneyChanged;
    }
}
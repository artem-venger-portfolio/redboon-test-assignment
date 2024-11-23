using System;

namespace Game.Assignment1
{
    public class Trade : ITrade
    {
        private readonly ICharacter _character;
        private readonly IMerchant _merchant;

        public Trade(ICharacter character, IMerchant merchant)
        {
            _character = character;
            _merchant = merchant;
        }

        public bool CanPurchase(Items item)
        {
            return MerchantInventory.HasItem(item) && GetPurchasePrice(item) <= _character.Money;
        }

        public void Purchase(Items item)
        {
            if (CanPurchase(item) == false)
            {
                throw new Exception($"Character can't purchase {item}");
            }

            CharacterMoney -= GetPurchasePrice(item);
        }

        public void Sell(Items item)
        {
            if (CharacterInventory.HasItem(item) == false)
            {
                throw new Exception($"Character can't sell {item}");
            }

            CharacterMoney += GetSellPrice(item);
        }

        private int CharacterMoney
        {
            get => _character.Money;
            set => _character.Money = value;
        }

        private IInventory CharacterInventory => _character.Inventory;

        private IInventory MerchantInventory => _merchant.Inventory;

        private int GetPurchasePrice(Items item)
        {
            return MerchantInventory.GetPrice(item);
        }

        private int GetSellPrice(Items item)
        {
            return CharacterInventory.GetPrice(item);
        }
    }
}
namespace Game.Assignment1
{
    public readonly struct ItemToQuantity
    {
        public ItemToQuantity(Items item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public Items Item { get; }

        public int Quantity { get; }
    }
}
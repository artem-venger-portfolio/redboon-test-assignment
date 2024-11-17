namespace Game.Assignment1
{
    public class SlotDefault : ISlot
    {
        public SlotDefault(Items item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public Items Item { get; }
        public int Quantity { get; private set; }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
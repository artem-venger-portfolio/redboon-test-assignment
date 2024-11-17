namespace Game.Assignment1
{
    public interface ISlot
    {
        Items Item { get; }
        int Quantity { get; }
        void AddQuantity(int quantity);
    }
}
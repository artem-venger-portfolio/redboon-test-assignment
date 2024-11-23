namespace Game.Assignment1
{
    public interface ITrade
    {
        bool CanPurchase(Items item);
        void Purchase(Items item);
        void Sell(Items item);
    }
}
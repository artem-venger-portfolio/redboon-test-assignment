namespace Game.Assignment1.PriceController
{
    public interface IPriceController
    {
        int GetPurchasePrice(Items item);
        int GetSellPrice(Items item);
    }
}
using Game.Assignment1;

namespace Game.Unity.Assignment1
{
    public readonly struct SlotViewInfo
    {
        public readonly Items Item;
        public readonly int Price;

        public SlotViewInfo(Items item, int price)
        {
            Item = item;
            Price = price;
        }
    }
}
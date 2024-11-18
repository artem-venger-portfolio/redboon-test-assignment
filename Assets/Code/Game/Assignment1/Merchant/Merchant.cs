using Game.Common;

namespace Game.Assignment1
{
    public class Merchant : IMerchant
    {
        private readonly IGameLogger _logger;

        public Merchant(IInventory inventory, IGameLogger logger)
        {
            _logger = logger;
            Inventory = inventory;
        }

        public IInventory Inventory { get; }
    }
}
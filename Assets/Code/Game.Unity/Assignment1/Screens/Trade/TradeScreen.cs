using Game.Assignment1;

namespace Game.Unity.Assignment1
{
    public class TradeScreen : TradeScreenBase
    {
        private ICharacter _character;
        private IMerchant _merchant;

        public override void Initialize(ICharacter character, IMerchant merchant)
        {
            _character = character;
            _merchant = merchant;
        }
    }
}
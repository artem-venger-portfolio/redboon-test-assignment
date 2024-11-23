using Game.Assignment1;
using TMPro;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class HUD : HUDBase
    {
        [SerializeField]
        private TMP_Text _coinsLabel;

        private ICharacter _character;

        public override void Initialize(ICharacter character)
        {
            _character = character;
            _character.MoneyChanged += MoneyChangedEventHandler;
            MoneyChangedEventHandler(_character.Money);
        }

        private void MoneyChangedEventHandler(int money)
        {
            _coinsLabel.text = money.ToString();
        }
    }
}
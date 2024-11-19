using Game.Assignment1;
using TMPro;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class SlotView : SlotViewBase
    {
        [SerializeField]
        private TMP_Text _nameLabel;

        [SerializeField]
        private TMP_Text _countLabel;

        public override void Initialize(Items item, int count)
        {
            _nameLabel.text = item.ToString();
            _countLabel.text = count.ToString();
        }
    }
}
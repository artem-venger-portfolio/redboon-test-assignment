using Game.Assignment1;
using Game.Common;
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

        [SerializeField]
        private DraggableObjectBase _draggableObject;

        public override void Initialize(Items item, int count, Transform draggingObjectContainer, IGameLogger logger)
        {
            _nameLabel.text = item.ToString();
            _countLabel.text = count.ToString();
            _draggableObject.Initialize(draggingObjectContainer, logger);
        }
    }
}
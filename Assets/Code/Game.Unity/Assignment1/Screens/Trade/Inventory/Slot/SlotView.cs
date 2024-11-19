using Game.Assignment1;
using Game.Common;
using TMPro;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    [RequireComponent(typeof(DraggableObjectBase))]
    public class SlotView : SlotViewBase
    {
        [SerializeField]
        private TMP_Text _nameLabel;

        [SerializeField]
        private TMP_Text _countLabel;

        private DraggableObjectBase _draggableObject;

        public override void Initialize(Items item, int count, IGameLogger logger)
        {
            _nameLabel.text = item.ToString();
            _countLabel.text = count.ToString();
            _draggableObject = GetComponent<DraggableObjectBase>();
            _draggableObject.Initialize(logger);
        }
    }
}
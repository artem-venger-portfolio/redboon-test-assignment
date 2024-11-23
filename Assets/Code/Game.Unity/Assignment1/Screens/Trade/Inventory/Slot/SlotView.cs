using System;
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
        private DraggableObjectBase _draggableObject;

        [SerializeField]
        private TMP_Text _priceLabel;

        public override Items Item { get; protected set; }

        public override event Action<Vector2> ItemDropped
        {
            add => _draggableObject.DragEnded += value;
            remove => _draggableObject.DragEnded -= value;
        }

        public override void Initialize(Items item, int price, Transform draggingObjectContainer, IGameLogger logger)
        {
            Item = item;
            _nameLabel.text = item.ToString();
            _priceLabel.text = price.ToString();
            _draggableObject.Initialize(draggingObjectContainer, logger);
        }

        public override void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
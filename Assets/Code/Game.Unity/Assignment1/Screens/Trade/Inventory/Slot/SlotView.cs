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

        public override event Action<Items, Vector2> ItemDropped;

        public override void Initialize(Items item, int price, Transform draggingObjectContainer, IGameLogger logger)
        {
            Item = item;
            _nameLabel.text = item.ToString();
            _priceLabel.text = price.ToString();
            _draggableObject.Initialize(draggingObjectContainer, logger);
            _draggableObject.DragEnded += DragEndedEventHandler;
        }

        public override void Destroy()
        {
            _draggableObject.DragEnded -= DragEndedEventHandler;
            Destroy(gameObject);
        }

        private void DragEndedEventHandler(Vector2 position)
        {
            ItemDropped?.Invoke(Item, position);
        }
    }
}
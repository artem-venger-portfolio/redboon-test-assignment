using System;
using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class InventoryView : InventoryViewBase
    {
        [SerializeField]
        private RectTransform _background;

        private readonly List<SlotViewBase> _slots = new List<SlotViewBase>();

        public override event Action<Vector2> ItemDropped;

        public override void Initialize(IList<SlotViewInfo> items, SlotViewBase slotTemplate,
                                        Transform draggingObjectCOntainer, IGameLogger logger)
        {
            foreach (var currentItem in items)
            {
                var slot = Instantiate(slotTemplate, transform);
                slot.Initialize(currentItem.Item, currentItem.Price, draggingObjectCOntainer, logger);
                slot.ItemDropped += ItemDroppedEventHandler;
                _slots.Add(slot);
            }
        }

        public override bool IsWithinBounds(Vector2 position)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(_background, position);
        }

        private void ItemDroppedEventHandler(Vector2 position)
        {
            ItemDropped?.Invoke(position);
        }
    }
}
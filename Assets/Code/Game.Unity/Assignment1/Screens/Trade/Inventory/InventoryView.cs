using System;
using System.Collections.Generic;
using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class InventoryView : InventoryViewBase
    {
        [SerializeField]
        private RectTransform _background;

        private readonly List<SlotViewBase> _slots = new List<SlotViewBase>();
        private IInventory _inventory;
        private SlotViewBase _slotTemplate;
        private Transform _draggingObjectContainer;
        private IGameLogger _logger;

        public override event Action<Vector2> ItemDropped;

        public override void Initialize(IInventory inventory, SlotViewBase slotTemplate,
                                        Transform draggingObjectCOntainer, IGameLogger logger)
        {
            _inventory = inventory;
            _slotTemplate = slotTemplate;
            _draggingObjectContainer = draggingObjectCOntainer;
            _logger = logger;

            _inventory.Changed += InventoryChangedEventHandler;
            foreach (var currentItem in inventory.Items)
            {
                AddSlot(currentItem);
            }
        }

        public override bool IsWithinBounds(Vector2 position)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(_background, position);
        }

        private void InventoryChangedEventHandler(Items item, InventoryOperation operation)
        {
            switch (operation)
            {
                case InventoryOperation.Add:
                    AddSlot(item);
                    break;
                case InventoryOperation.Remove:
                    RemoveSlot(item);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation,
                                                          $"Unknown operation: {operation}");
            }
        }

        private void AddSlot(Items item)
        {
            var currentPrice = _inventory.GetPrice(item);
            var slot = Instantiate(_slotTemplate, transform);
            slot.Initialize(item, currentPrice, _draggingObjectContainer, _logger);
            slot.ItemDropped += ItemDroppedEventHandler;
            _slots.Add(slot);
        }

        private void RemoveSlot(Items item)
        {
            for (var i = 0; i < _slots.Count; i++)
            {
                var currentSlot = _slots[i];
                if (currentSlot.Item != item)
                {
                    continue;
                }

                currentSlot.ItemDropped -= ItemDroppedEventHandler;
                currentSlot.Destroy();
                _slots.RemoveAt(i);
                break;
            }
        }

        private void ItemDroppedEventHandler(Vector2 position)
        {
            ItemDropped?.Invoke(position);
        }
    }
}
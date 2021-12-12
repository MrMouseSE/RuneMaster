using System.Collections.Generic;
using UnityEngine;

namespace InventoryMenu.InventoryScripts
{
    public class InventorySlotsHandler : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots;

        private void Awake()
        {
            foreach (var inventorySlot in _inventorySlots)
            {
                inventorySlot.SetHandler(this);
            }
        }

        public InventoryItem[] GetInventoryItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();
            foreach (var inventorySlot in _inventorySlots)
            {
                if(!inventorySlot.IsItemSlotEmpty()) items.Add(inventorySlot.GetItem());
            }

            return items.ToArray();
        }

        public bool TrySetItemToEmptySlot(InventoryItem item)
        {
            foreach (var inventorySlot in _inventorySlots)
            {
                if (!inventorySlot.IsItemSlotEmpty()) continue;
                inventorySlot.SetItem(item);
                return true;
            }

            return false;
        }

        public void SwapSlotsItems(InventorySlot slot)
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (_inventorySlots[i] == slot)
                {
                    var firstItem = _inventorySlots[i].GetItem();
                    var index = i++;
                    if (index == _inventorySlots.Length) index = 0;
                    var secondItem = _inventorySlots[index].GetItem();
                    _inventorySlots[i].SetItem(secondItem);
                    _inventorySlots[index].SetItem(firstItem);
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryScripts
{
    public class InventorySlot : MonoBehaviour, IPointerClickHandler
    {
        private InventorySlotsHandler _handler;
        [SerializeField]
        private InventoryItem _item;

        public void SetHandler(InventorySlotsHandler handler)
        {
            _handler = handler;
        }

        public void SetItem(InventoryItem item)
        {
            if (item == null)
            {
                _item = null;
                return;
            }
            var itemTransform = item.transform;
            itemTransform.parent = transform;
            itemTransform.localPosition = Vector3.zero;
            _item = item;
        }

        public InventoryItem GetItem()
        {
            return _item;
        }

        public bool IsItemSlotEmpty()
        {
            return _item == null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right && _item != null) _item.DestroyItem();
            if (eventData.button == PointerEventData.InputButton.Left) _handler.SwapSlotsItems(this);
        }
    }
}
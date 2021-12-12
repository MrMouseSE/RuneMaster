using InventoryMenu.InventoryScripts;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private InventorySlotsHandler _handler;
    private InventoryItem _item;

    public void SetHandler(InventorySlotsHandler handler)
    {
        _handler = handler;
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(1) && _item != null) _item.DestroyItem();
        if (Input.GetMouseButton(0)) _handler.SwapSlotsItems(this);
    }

    public void SetItem(InventoryItem item)
    {
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
}
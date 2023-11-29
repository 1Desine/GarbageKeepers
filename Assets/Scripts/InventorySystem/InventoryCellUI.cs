using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellUI : MonoBehaviour {

    public Image itemImage;

    public InventoryItemSO inventoryItemSO;

    public int index;

    public void SetItem(InventoryItemSO inventoryItemSO) {
        this.inventoryItemSO = inventoryItemSO;
        itemImage.sprite = inventoryItemSO.sprite;
        itemImage.enabled = true;
    }
    public void RemoveItem() {
        inventoryItemSO = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }

}

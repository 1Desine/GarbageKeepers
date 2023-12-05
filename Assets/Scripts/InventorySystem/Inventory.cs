using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class Inventory : MonoBehaviour {
    static public Inventory Instance { get; private set; }

    // 0-9 Bag, 10 Hand, 11-13 QuikSlot, 14 Amulet, 15 Jacket, 16 Pants, 17 Shoes
    public List<Cell> cells;

    private PlayerController CharacterMovement;

    static public Action<List<Cell>> OnItemsUpdated = _ => { };

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        UpdateInventoryItems();

        CharacterMovement = GetComponent<PlayerController>();
    }

    static public void UpdateInventoryItems() {
        if (Instance == null) return;
        OnItemsUpdated(Instance.cells);
    }
    public void RemoveItem(int index) {
        cells[index].inventoryItemSO = null;
        UpdateInventoryItems();
    }

    public void TryDropItem(int index) {
        if (cells[index].inventoryItemSO != null) {
            CharacterMovement.GetItemDropPositioning(out Vector3 position, out Quaternion rotation);
            SpawnManager.SpawnObject(cells[index].inventoryItemSO.prefab, position, rotation);
            RemoveItem(index);
        }
    }
    public bool TryPickUpItem(InventoryItemSO inventoryItemSO) {
        if (TryAddItemToInventory(inventoryItemSO)) {
            UpdateInventoryItems();
            return true;
        }
        return false;
    }
    private bool TryAddItemToInventory(InventoryItemSO inventoryItemSO) {
        for (int i = 0; i < cells.Count; i++) {
            // search for best slot for the item, not in the Bag and after that
            // search for ampty slot in the Bag [0;9]
            int c = (i + 10) % cells.Count;
            if (cells[c].inventoryItemSO != null) continue;
            if (inventoryItemSO.compatibleCellsByType.Contains(cells[c].cellType)) {
                cells[c].SetItem(inventoryItemSO);
                return true;
            }
        }
        return false;
    }

    public bool TryGetItem(int index, out InventoryItemSO item) {
        if (cells[index].inventoryItemSO is InventoryItemSO foundItem) {
            item = foundItem;
            return true;
        }
        item = null;
        return false;
    }
    public List<InventoryItemSO> GetItemsList() {
        List<InventoryItemSO> items = new();
        foreach(Cell cell in cells) {
            if(cell.inventoryItemSO != null) items.Add(cell.inventoryItemSO);
        }
        return items;
    }

    [Serializable]
    public class Cell {

        public InventoryItemSO inventoryItemSO;

        public CellType cellType;
        public enum CellType {
            Bag, //0-9
            Hand, // 10
            QuickSlot, // 11-13
            Amulet, // 14
            Jacket, // 15
            Pants, // 16
            Shoes, // 17
        }

        public void SetItem(InventoryItemSO inventoryItemSO) {
            this.inventoryItemSO = inventoryItemSO;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;



public class Inventory : MonoBehaviour {
    static public Inventory Instance { get; private set; }

    // 0-9 Bag, 10 Hand, 11-13 QuikSlot, 14 Amulet, 15 Jacket, 16 Pants, 17 Shoes
    public List<Cell> cells;

    private PlayerController CharacterMovement;


    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;

        Instance = this;
    }
    private void Start() {
        InventoryUI.Instance.UpdateItems(cells);

        CharacterMovement = GetComponent<PlayerController>();
    }
    private void OnEnable() {
        InputManager.OnPickUpItem += InputManager_OnPickUpItem;
    }
    private void OnDisable() {
        InputManager.OnPickUpItem -= InputManager_OnPickUpItem;
    }


    public void RemoveItem(int index) {
        cells[index].inventoryItemSO = null;
        InventoryUI.Instance.UpdateItems(cells);
    }

    public void InputManager_OnPickUpItem() {
        float pickUpDistance = 3;
        if (CharacterMovement.LookingAt(pickUpDistance, out RaycastHit hit)) {
            if (hit.collider.TryGetComponent(out ItemObject itemObject)) TryPickUpItem(itemObject);
        }
    }
    public void TryDropItem(int index) {
        if (cells[index].inventoryItemSO != null) {
            if (SpawnManager.TryDropInventoryItem(cells[index].inventoryItemSO, CharacterMovement.GetItemDropPoint())) {
                RemoveItem(index);
            }
        }
    }
    private void TryPickUpItem(ItemObject itemObject) {
        if (TryAddItemToInventory(itemObject.inventoryItemSO)) {
            Destroy(itemObject.gameObject);
            InventoryUI.Instance.UpdateItems(cells);
        }
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

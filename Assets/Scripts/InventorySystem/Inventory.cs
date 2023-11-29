using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Inventory : MonoBehaviour {
    static public Inventory Instance { get; private set; }

    // 0-9 Bag, 10 Hand, 11-13 QuikSlot, 14 Amulet, 15 Jacket, 16 Pants, 17 Shoes
    [SerializeField] List<Cell> cells;

    private CharacterMovement CharacterMovement;

    private bool inventoryIsVisible;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;

        Instance = this;
    }
    private void Start() {
        InventoryUI.Instance.UpdateItems(cells);

        CharacterMovement = GetComponent<CharacterMovement>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            inventoryIsVisible = !inventoryIsVisible;
            if (inventoryIsVisible) {
                InventoryUI.Instance.Show();
                Cursor.lockState = CursorLockMode.None;
            }
            else {
                InventoryUI.Instance.Hide();
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (CharacterMovement.LookingAt(out RaycastHit hit)) {
                if (hit.collider.TryGetComponent(out ItemObject itemObject)) TryPickUpItem(itemObject);
            }
        }
    }

    public void TryDropItem(int index) {
        if (cells[index].inventoryItemSO != null) {
            if (SpawnManager.TryDropInventoryItem(cells[index].inventoryItemSO, CharacterMovement.GetItemDropPoint())) {
                cells[index].inventoryItemSO = null;
                InventoryUI.Instance.UpdateItems(cells);
            }
        }
    }
    private void TryPickUpItem(ItemObject itemObject) {
        int placedItemIndex = -1;

        // search for best slot for the item, not in the Bag
        for (int i = 10; i < cells.Count; i++) {
            if (itemObject.inventoryItemSO.compatibleCellsByType.Contains(cells[i].cellType)) {
                placedItemIndex = i;
                break;
            }
        }
        // search for ampty slot in the Bag [0;9]
        if (placedItemIndex == -1) {
            for (int i = 0; i < 10; i++) {
                if (itemObject.inventoryItemSO.compatibleCellsByType.Contains(cells[i].cellType)) {
                    placedItemIndex = i;
                    break;
                }
            }
        }
        if (placedItemIndex != -1) {
            cells[placedItemIndex].SetItem(itemObject.inventoryItemSO);
            Destroy(itemObject.gameObject);
            InventoryUI.Instance.UpdateItems(cells);
        }
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

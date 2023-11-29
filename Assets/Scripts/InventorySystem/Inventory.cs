using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Inventory : MonoBehaviour {
    static public Inventory Instance { get; private set; }


    [SerializeField] List<Cell> cells;

    private CharacterMovement CharacterMovement;

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
            InventoryUI.Instance.Show();
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            InventoryUI.Instance.Hide();
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if(CharacterMovement.LookingAt(out RaycastHit hit)) {
                Debug.Log("E, I'm looking at something");
                if (hit.collider.TryGetComponent(out ItemObject itemObject)) TryPickUpItem(itemObject);
            }
        }
    }

    public void TryDropItem(int index) {
        if (cells[index].inventoryItemSO != null) {
            SpawnManager.Instance.DropInventoryItem(cells[index].inventoryItemSO, CharacterMovement.GetItemDropPoint());
            cells[index].inventoryItemSO = null;

            InventoryUI.Instance.UpdateItems(cells);
        }
    }
    private void TryPickUpItem(ItemObject itemObject) {
        cells[0].inventoryItemSO = itemObject.consumableItemSO;
        Destroy(itemObject.gameObject);

        InventoryUI.Instance.UpdateItems(cells);
    }


    [Serializable]
    public class Cell {

        public InventoryItemSO inventoryItemSO;

        public CellType cellType;
        public enum CellType {
            Bag,
            MainHand,
            SecondaryHand,
            Jacket,
            Pants,
            Shoe,
        }

        public void AddItem(int index, InventoryItemSO item) {

        }
        public void RemoveItem(int index) {

        }
    }

}

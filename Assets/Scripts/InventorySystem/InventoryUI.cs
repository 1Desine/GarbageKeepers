using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    static public InventoryUI Instance { get; private set; }


    [SerializeField] List<InventoryCellUI> inventoryCells;

    private GraphicRaycaster raycaster;
    private PointerEventData clickData;
    private List<RaycastResult> clickResults;

    private void Awake() {
        Instance = this;

        raycaster = transform.parent.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();

        for (int i = 0; i < inventoryCells.Count; i++) {
            inventoryCells[i].index = i;
        }
    }

    private void OnEnable() {
        InputManager.OnInventoryDropItemDown += InputManager_OnInventoryDropItemDown;
    }
    private void OnDisable() {
        InputManager.OnInventoryDropItemDown -= InputManager_OnInventoryDropItemDown;
    }

    public void UpdateItems(List<Inventory.Cell> inventoryCellsList) {
        for (int i = 0; i < inventoryCells.Count; i++) {
            if (inventoryCellsList[i].inventoryItemSO == null) inventoryCells[i].RemoveItem();
            else inventoryCells[i].SetItem(inventoryCellsList[i].inventoryItemSO);
        }
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
    public void Show() {
        gameObject.SetActive(true);
    }

    private void InputManager_OnInventoryDropItemDown(Vector2 mousePosition) {
        clickData.position = mousePosition;
        clickResults.Clear();
        raycaster.Raycast(clickData, clickResults);


        List<InventoryCellUI> clickedObjects = new List<InventoryCellUI>();
        foreach (RaycastResult result in clickResults) {
            if (result.gameObject.TryGetComponent(out InventoryCellUI inventoryCellUI)) clickedObjects.Add(inventoryCellUI);
        }
        if (clickedObjects.Count > 1) Debug.LogError("me. UI elements are stacked: " + clickResults.Count);

        if (clickedObjects.Count != 0) Inventory.Instance.TryDropItem(clickedObjects[0].index);
    }

}

using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Character : Entity {

    private Inventory inventory;
    [SerializeField] GameObject visual;

    private void Awake() {
        health = 100;
        entityName = "Character";

        inventory = GetComponent<Inventory>();

        SetGameLayerRecursive(visual, 7);
    }
    private void SetGameLayerRecursive(GameObject _go, int _layer) {
        _go.layer = _layer;
        foreach (Transform child in _go.transform) {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);

        }
    }

    protected override void PrepairItemsToDropAndDie() {
        if (inventory.cells.Count != 0)
            foreach (var cell in inventory.cells)
                if (cell.inventoryItemSO != null)
                    itemsToDropOnDied.Add(cell.inventoryItemSO);
        base.PrepairItemsToDropAndDie();
    }


}

using UnityEngine;

public class Character : Entity {

    private Inventory inventory;

    private void Awake() {
        health = 100;
        entityName = "Character";

        inventory = GetComponent<Inventory>();
    }

    protected override void PrepairItemsToDropAndDie() {
        if (inventory.cells.Count != 0)
            foreach (var cell in inventory.cells)
                if (cell.inventoryItemSO != null)
                    itemsToDropOnDied.Add(cell.inventoryItemSO);
        base.PrepairItemsToDropAndDie();
    }


}

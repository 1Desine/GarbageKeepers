using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable {


    public InventoryItemSO inventoryItemSO;


    public void Interact(GameObject actor) {
        if (actor.TryGetComponent(out Inventory inventory))
            if (inventory.TryPickUpItem(inventoryItemSO))
                Destroy(gameObject);
    }


}

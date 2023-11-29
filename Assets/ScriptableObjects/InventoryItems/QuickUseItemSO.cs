using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemsSO/QuickUse")]
public abstract class QuickUseItemSO : InventoryItemSO {

    public virtual void DoEffect(Character character) {
        Debug.LogError("me. Base method was used");
    }


}

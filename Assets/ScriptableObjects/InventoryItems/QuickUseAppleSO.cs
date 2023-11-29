using UnityEngine;

[CreateAssetMenu(fileName = "Apple", menuName = "Inventory/ItemsSO/QuickUse/Apple")]
public class QuickUseAppleSO : QuickUseItemSO {

    public int healthRegeneration;

    public override void DoEffect(Character character) {
        character.Heal(healthRegeneration);
    }


}

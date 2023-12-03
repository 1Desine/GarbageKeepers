using UnityEngine;

public class CharacterItemsHandler : MonoBehaviour {

    private Inventory inventory;
    private PlayerController movement;
    private Character character;


    private float lastAttackTime;
    private float coolDown;

    private void Awake() {
        inventory = GetComponent<Inventory>();
        movement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
    }


    private void OnEnable() {
        InputManager.OnAttackDown += InputManager_OnAttackDown;
        InputManager.OnUseQuickSlot += InputManager_OnUseQuickSlot;
    }
    private void OnDisable() {
        InputManager.OnAttackDown -= InputManager_OnAttackDown;
        InputManager.OnUseQuickSlot -= InputManager_OnUseQuickSlot;
    }

    private void InputManager_OnAttackDown() {
        if (Time.time - lastAttackTime < this.coolDown) return;
        lastAttackTime = Time.time;


        float attackDistance = 1;
        int damage = 5;
        float coolDown = 0.3f;
        if (inventory.TryGetItem(10, out InventoryItemSO item)) {
            WeaponItemSO weaponItemSO = item as WeaponItemSO;

            attackDistance = weaponItemSO.attackDistance;
            damage = weaponItemSO.damage;
            coolDown = weaponItemSO.cooldown;
        }

        if (movement.LookingAt(attackDistance, out RaycastHit hit)) {
            if (hit.transform.root.TryGetComponent(out Entity entity)) {
                entity.Damage(damage);
                this.coolDown = coolDown;
            }
        }
    }

    private void InputManager_OnUseQuickSlot(int index) {
        if (inventory.TryGetItem(11 + index, out InventoryItemSO item)) {
            QuickUseItemSO quickUseItemSO = item as QuickUseItemSO;
            quickUseItemSO.DoEffect(character);
            inventory.RemoveItem(11 + index);
            Debug.Log("QuickItem by index: " + index + " with name: " + item.itemName + " was used");
        }
    }

}

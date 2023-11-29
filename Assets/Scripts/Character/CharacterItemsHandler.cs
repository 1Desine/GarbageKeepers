using UnityEngine;

public class CharacterItemsHandler : MonoBehaviour {

    private Inventory inventory;
    private CharacterMovement movement;
    private Character character;


    private float lastAttackTime;
    private float coolDown;

    private void Awake() {
        inventory = GetComponent<Inventory>();
        movement = GetComponent<CharacterMovement>();
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
        if (Time.time - lastAttackTime < coolDown) return;

        lastAttackTime = Time.time;
        if (inventory.TryGetItem(10, out InventoryItemSO item)) {
            WeaponItemSO weaponItemSO = item as WeaponItemSO;
            coolDown = weaponItemSO.cooldown;
            if (movement.LookingAt(weaponItemSO.attackDistance, out RaycastHit hit)) {
                if (hit.collider.TryGetComponent(out Entity entity)) {
                    entity.Damage(weaponItemSO.damage);
                    Debug.Log("Attack with Item: " + weaponItemSO.tag + " with name: " + weaponItemSO.itemName);
                }
            }
        }
        else {
            coolDown = 0.3f;
            float attackDistance = 1f;
            int damage = 5;
            if (movement.LookingAt(attackDistance, out RaycastHit hit)) {
                if (hit.collider.TryGetComponent(out Entity entity)) {
                    entity.Damage(damage);
                    Debug.Log("Attack with empty hand");
                }
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

using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected string entityName;
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    protected List<InventoryItemSO> itemsToDropOnDied = new List<InventoryItemSO>();

    public void Heal(int heal) {
        health += heal;
        health = Mathf.Max(health, maxHealth);
        Debug.Log("I got healed", this);
    }
    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) PrepairAndDie();
    }
    protected virtual void PrepairAndDie() {
        Die();
    }
    private void Die() {
        foreach (InventoryItemSO item in itemsToDropOnDied) {
            float angle = Random.Range(0, 360f) * Mathf.Deg2Rad;
            float upOffset = 0.5f;
            float maxDistance = 1;
            Vector3 position = new Vector3(Mathf.Sin(angle), upOffset, Mathf.Cos(angle)) * Random.Range(0, maxDistance);
            Vector3 direction = Vector3.up;

            if (Physics.Raycast(transform.position + position, Vector3.down, out RaycastHit hit)) {
                position = transform.position + position + Vector3.down * (hit.distance - 0.1f);
                direction = hit.normal;
            }
            SpawnManager.SpawnObject(item.prefab, position, Quaternion.Euler(direction));
        }
        Destroy(gameObject);
        Debug.Log("Enity " + entityName + " died", this);
    }


}

using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected string entityName;
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    protected List<InventoryItemSO> itemsToDropOnDied = new List<InventoryItemSO>();

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) PrepairItemsToDropAndDie();
    }
    public void Heal(int heal) {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("I got healed", this);
    }
    protected virtual void PrepairItemsToDropAndDie() {
        Die();
    }
    private void Die() {
        foreach (InventoryItemSO item in itemsToDropOnDied) {
            float angle = Random.Range(0, 360f) * Mathf.Deg2Rad;
            float upOffset = 0.5f;
            Vector3 randomDirection = new Vector3(Mathf.Sin(angle), upOffset, Mathf.Cos(angle));
            randomDirection *= Random.Range(0, 1f);

            SpawnManager.TryDropInventoryItem(item, transform.position + randomDirection);
        }
        Destroy(gameObject);
        Debug.Log("Enity " + entityName + " died", this);
    }


}

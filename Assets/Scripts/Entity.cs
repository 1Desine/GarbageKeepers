using UnityEngine;

public class Entity : MonoBehaviour {

    protected string entityName;
    protected int health;
    protected int maxHealth;


    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) Debug.Log("Enity " + entityName + " died", this);
    }
    public void Heal(int heal) {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("I got healed", this);
    }



}

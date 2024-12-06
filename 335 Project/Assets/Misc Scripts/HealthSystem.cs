using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public GameObject tempHeal;
    public enum Type { player, enemy };
    public Type myType;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Current health: " +  currentHealth);
        //couldn't get enum to work
        if (currentHealth <= 0 && myType == Type.player)
        {
            //Lose screen Logic
        }
        else if (currentHealth <= 0 && myType == Type.enemy)
        {
            Instantiate(tempHeal, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    
    public void Heal(int healAmount)
    {
        if (myType == Type.player)
        {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Current health: " + currentHealth);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}

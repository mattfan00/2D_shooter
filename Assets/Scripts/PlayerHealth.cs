using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;

    public Health healthBar;
    public GameObject deathEffect;
    public GameObject followTag;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0) {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(followTag);
        }
    }
}

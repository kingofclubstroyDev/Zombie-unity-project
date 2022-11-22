using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

    private int maxHealth;
    private int currentHealth;

    
    
    public void initialize(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;

    }

    public bool attack(int damage) {

        if(currentHealth <= damage) {
            return true;
        }

        currentHealth -= damage;
        
        GameEvents.instance.UnitAttackTarget(gameObject);

        return false;
    }

    public void heal(int healing) {

        currentHealth += healing;

        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

    }

}

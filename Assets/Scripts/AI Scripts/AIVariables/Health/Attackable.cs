using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

    private float maxHealth;
    [SerializeField] private float currentHealth;

    public void initialize(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;

    }

    public bool attack(float damage) {

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

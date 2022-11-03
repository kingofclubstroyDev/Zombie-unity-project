using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

    private int maxHealth;
    private int currentHealth;

    [SerializeField] AIVariables variables;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = variables.health;
        currentHealth = maxHealth;

    }

    public bool attack(int damage) {

        print("being attacked");

        if(currentHealth <= damage) {
            Destroy(gameObject);
            return true;
        }

        currentHealth -= damage;

        print("current health = " + currentHealth);

        return false;
    }

    public void heal(int healing) {

        currentHealth += healing;

        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

    }

}

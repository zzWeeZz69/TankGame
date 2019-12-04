using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPScript : MonoBehaviour
{

    [Header("Inputs")]
    public string player;

    [Header("Health Components")]
    public int health;
    public int maxHealth = 100;


    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

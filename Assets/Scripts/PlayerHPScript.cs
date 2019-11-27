using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPScript : MonoBehaviour
{

    [Header("Inputs")]
    public string player;

    [Header("Health Components")]
    public int health;
    public int maxHealth = 12;


    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
            
    }

}

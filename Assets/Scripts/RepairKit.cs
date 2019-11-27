﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    PlayerHPScript PlayerHealth;

    public int Heal = 10;

    void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHPScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (PlayerHealth.health < PlayerHealth.maxHealth)
        {
            PlayerHealth.health += Heal;
            Destroy(gameObject);
        }
    }
}

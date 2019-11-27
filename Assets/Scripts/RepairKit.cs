using System.Collections;
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

    void OnTriggerEnter(Collider collider)
    {
        if (PlayerHealth.health < PlayerHealth.maxHealth)
        {
            PlayerHealth.health = PlayerHealth.health + Heal;
            Destroy(gameObject);
        }
    }
}

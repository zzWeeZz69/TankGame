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

    public void OnCollisionEnter(Collision collision)
    {
        if (PlayerHealth.health < PlayerHealth.maxHealth && collision.gameObject.tag == "Player")
        {
            PlayerHealth.health += Heal;
            Destroy(gameObject);
        }
    }
}

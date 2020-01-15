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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //&& PlayerHealth.health < PlayerHealth.maxHealth)
        {
            Debug.Log("911");
            PlayerHealth.health += Heal;
            if(PlayerHealth.health > PlayerHealth.maxHealth)
            {
                PlayerHealth.health = PlayerHealth.maxHealth;
            }
            Destroy(gameObject);
        }
    }
}

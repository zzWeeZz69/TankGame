using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    PlayerHPScript PlayerHealth;
    public int damge = 20;
    public float cooldown = 3f;
    public float readyIn;

    void Awake()
    {
        readyIn = cooldown;
        readyIn -= Time.deltaTime;
        PlayerHealth = FindObjectOfType<PlayerHPScript>();
    }
    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Player" && readyIn == 0)
        {
            PlayerHealth.health -= damge;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int whoOwnes;
    PlayerHPScript PlayerHealth;
    public int damge = 20;
    public float cooldown = 3f;
    public float readyIn;

    void Awake()
    {
        readyIn = cooldown;
        readyIn -= Time.deltaTime;

    }
    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Player" && readyIn <= 0 && Collision.gameObject.GetComponent<TankController>().Player != whoOwnes)
        {
            PlayerHealth = Collision.GetComponent<PlayerHPScript>();
            PlayerHealth.health -= damge;

            Destroy(gameObject);
        }
    }
}

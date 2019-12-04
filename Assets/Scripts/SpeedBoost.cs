using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    TankMovement movement_speed;
    public float speedBost = 10;

    private void Awake()
    {
        
    }


    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TankMovement.i.movement_speed += speedBost;
            Destroy(gameObject);
        }
    }
}

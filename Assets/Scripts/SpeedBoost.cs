using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    TankMovement movement_speed;
    public float speedBost = 10;
    public float duration = 5;
    public float currentDuration;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TankMovement.i.movement_speed += speedBost;
            currentDuration = duration;
            currentDuration =- Time.deltaTime;
            Destroy(gameObject);
        }
    }

    public void timer()
    {
        if (currentDuration < 0)
        {
            TankMovement.i.movement_speed -= speedBost;
        }
    }
}

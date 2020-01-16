using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    TankController movement_speed;
    public float speedBoost = 10;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Im SPEED");
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 3;

    //if(Input.GetButton())

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerHPScript>().health -= damage;
            Destroy(gameObject);
        }
        else if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}

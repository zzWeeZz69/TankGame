using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 20;
    private Rigidbody rb;

    //if(Input.GetButton())

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
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

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 10f;
    public bool createrForce = true;
    public bool shouldExplode = false;
    public float lifeTime = 10f;

    public float power = 10f;
    public float radius = 5f;
    public float upwardThrust = 3f;
    public GameObject explosion;
    private Collider[] overlappers;
    AudioSource explosionSound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        explosionSound = GameObject.Find("ExplosionSoundObject").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (createrForce)
        {
            rb.AddForce(transform.forward * thrust);
            createrForce = false;
        }
        if (shouldExplode)
        {
            Collider[] colliders = GetOverlappers();

            explosionSound.Play();

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, this.transform.position, radius, upwardThrust);
                }
            }
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        shouldExplode = true;
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }

    Collider[] GetOverlappers()
    {
        return Physics.OverlapSphere(this.transform.position, radius);
    }
}

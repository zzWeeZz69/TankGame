using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] ParticleSystem pickupParticles;
    private Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupParticles.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(pickupParticles, transform.position, transform.rotation);
            Destroy(gameObject);
            pickupParticles.Play();
        }
    }
}

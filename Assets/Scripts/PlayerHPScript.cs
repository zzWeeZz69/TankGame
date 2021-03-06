﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPScript : MonoBehaviour
{
    [HideInInspector]
    public bool dead = false; 

    [Header("Health Components")]
    public int health;
    public int maxHealth = 100;

    new Rigidbody rigidbody;
    public Vector3 position, velocity, angularVelocity;
    public bool isColliding;
    public GameObject model;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            dead = true;
            model.SetActive(false);
        }
        else
        {
            model.SetActive(true);
        }
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isColliding)
        {
            position = rigidbody.position;
            velocity = rigidbody.velocity;
            angularVelocity = rigidbody.angularVelocity;
        }
    }

    void LateUpdate()
    {
        if (isColliding)
        {
            rigidbody.position = position;
            rigidbody.velocity = velocity;
            rigidbody.angularVelocity = angularVelocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Damage")
            isColliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Damage")
            isColliding = false;
    }
}

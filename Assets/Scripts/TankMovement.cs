using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    #region vars
    [SerializeField] float movement_speed;
    [SerializeField] float turnSpeed;
    [SerializeField] Vector2 TurnLock;

    private Rigidbody rb;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
    }

    private void MoveTank()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 wantedPos = transform.position + (transform.forward * movement_speed * Time.deltaTime);
            rb.MovePosition(wantedPos);
        }
        if (Input.GetButton("Jump"))
        {
            Vector3 wantedPos = transform.position + (transform.forward * -movement_speed/2 * Time.deltaTime);
            rb.MovePosition(wantedPos);
        }
        transform.Rotate(new Vector3(0, turnSpeed * Input.GetAxis("Horizontal"), 0));
    }
}

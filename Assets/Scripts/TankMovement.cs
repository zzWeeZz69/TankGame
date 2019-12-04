using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    #region vars
    [SerializeField] float movement_speed;
    [SerializeField] float turnSpeed;
    [Range(-1, 1)] float currdir;
    [SerializeField] float ForceToqe;
    public static State state;

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
            state = State.MoveForwards;
            rb.MovePosition(wantedPos);
            currdir = 1;
        }
        else if (Input.GetButton("Jump"))
        {
            Vector3 wantedPos = transform.position + (transform.forward * -movement_speed/2 * Time.deltaTime);
            state = State.MoveBackwards;
            rb.MovePosition(wantedPos);
            currdir = -1;
        }
        else
        {
            state = State.stopped;
            
        }
        transform.Rotate(new Vector3(0, turnSpeed * Input.GetAxis("Horizontal"), 0));

    }
    public enum State
    {
        stopped,
        MoveForwards,
        MoveBackwards
    }
}

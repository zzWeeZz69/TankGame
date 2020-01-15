using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    #region vars
    public int Player;
    public static TankMovement i
    {
        get; private set;
    }
    [SerializeField] public float movement_speed;
    [SerializeField] public float turnSpeed;
    [SerializeField] float MaxTilt;

    private Rigidbody rb;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
    }

    private void MoveTank()
    {
        float Drive = Input.GetAxis("Drive_" + Player.ToString());
            Vector3 wantedPos = transform.position + (transform.forward * (Drive * movement_speed) * Time.deltaTime);
            rb.MovePosition(wantedPos);
        transform.Rotate(new Vector3(0, turnSpeed * Input.GetAxis("Turn_" + Player.ToString()), 0));
    }
}

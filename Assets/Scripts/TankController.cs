using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    #region vars
    public int Player;
    public static TankController i
    {
        get; private set;
    }
    [SerializeField] public float movement_speed;
    [SerializeField] public float turnSpeed;
    [SerializeField] float MaxTilt;

    private PlayerHPScript hp;
    private Rigidbody rb;
    public GameObject SpeedBoost;

    bool checkIsSb = false;
    bool timeIsOver = false;
    public float cooldown = 5;
    public float currentTimer;
    SpeedBoost sb = null;
    RepairKit rk = null;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = GetComponent<PlayerHPScript>();
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
        if (checkIsSb)
        {

            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                movement_speed -= sb.speedBoost;
                checkIsSb = false;
            }
        }
    }

    private void MoveTank()
    {
        float Drive = Input.GetAxis("Drive_" + Player.ToString());
        Vector3 wantedPos = transform.position + (transform.forward * (Drive * movement_speed) * Time.deltaTime);
        rb.MovePosition(wantedPos);
        transform.Rotate(new Vector3(0, turnSpeed * Input.GetAxis("Turn_" + Player.ToString()), 0));
    }

    private void OnTriggerEnter(Collider collision)
    {

        // om den detectar pickup
        if (collision.gameObject.tag == "PickUp")
        {

            if (collision.gameObject.GetComponent<RepairKit>() != null)
            {
                rk = collision.gameObject.GetComponent<RepairKit>();
                hp.health += rk.Heal;
            }
            if (collision.gameObject.GetComponent<SpeedBoost>() != null)
            {
                sb = collision.gameObject.GetComponent<SpeedBoost>();
                movement_speed += sb.speedBoost;
                currentTimer = cooldown;
                checkIsSb = true;
                if (timeIsOver)
                {
                    movement_speed -= sb.speedBoost;
                }
            }
        }

        // checka vilken pickup

        // ge rätt buff
    }
}

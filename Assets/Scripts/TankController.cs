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
    public ActiveControls activeControls;

    [SerializeField] public float movement_speed;
    [SerializeField] public float turnSpeed;
    [SerializeField] public GameObject MinePrefab;
    [SerializeField] public Transform MineDropPoint;
    [SerializeField] float MaxTilt;
    AudioSource EngineSound;

    private PlayerHPScript hp;
    [SerializeField] PlayerShootScript ps;
    private Rigidbody rb;
    public GameObject SpeedBoost;

    public bool stun;
    bool checkIsSb = false;
    bool timeIsOver = false;
    public float cooldown = 5;
    public float currentTimer;
    public bool Dead;
    SpeedBoost sb = null;
    RepairKit rk = null;
    Animator anim;
    float MineCoolDown = 1.5f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        EngineSound = GameObject.Find("EngineSoundObject").GetComponent<AudioSource>();
        EngineSound.Play();
        rb = GetComponent<Rigidbody>();
        hp = GetComponent<PlayerHPScript>();
        anim = GetComponent<Animator>();
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        Dead = hp.dead;
        switch (activeControls)
        {
            case ActiveControls.FullControllOn:
                DropMine(MinePrefab, MineDropPoint);
                MoveTank();
                ps.DisableShoot = false;
                break;
            case ActiveControls.MovementOff_WeponsOn:
                DropMine(MinePrefab, MineDropPoint);
                ps.DisableShoot = false;
                break;
            case ActiveControls.FullControllOff:
                ps.DisableShoot = true;
                break;
        }

        if (checkIsSb)
        {

            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                movement_speed -= sb.speedBoost;
                checkIsSb = false;
            }
        }
        if (stun)
        {
            StartCoroutine(stunTank(0.5f));
        }
    }
    float time;
    private void DropMine(GameObject Mine, Transform dropPoint)
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        Debug.Log(Mine, dropPoint);
        if (Input.GetButtonDown("DropMine_" + Player.ToString()) && time <= 0)
        {
            time = MineCoolDown;
            Debug.Log("buttonPressed");
            var mine = Instantiate(Mine, dropPoint.position, Quaternion.identity);
            Debug.Log("MineSpawned");
            
            switch (Player)
            {
                case 1:
                    mine.GetComponent<Mine>().whoOwnes = 1;
                    break;
                case 2:
                    mine.GetComponent<Mine>().whoOwnes = 2;
                    break;
            }
            
        }

    }

    private void MoveTank()
    {
        float Drive = Input.GetAxis("Drive_" + Player.ToString());
        Debug.Log(Drive + Player.ToString());
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

    public IEnumerator stunTank(float time)
    {
        activeControls = ActiveControls.FullControllOff;
        anim.SetBool("Stun", true);
        yield return new WaitForSeconds(time);
        stun = false;
        anim.SetBool("Stun", false);
        activeControls = ActiveControls.FullControllOn;
    }
    public enum ActiveControls
    {
        FullControllOn,
        MovementOff_WeponsOn,
        FullControllOff
    }

}

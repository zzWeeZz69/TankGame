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

    bool checkIsSb = false;
    bool timeIsOver = false;
    public float cooldown = 5;
    public float currentTimer;
    public bool Dead;
    SpeedBoost sb = null;
    RepairKit rk = null;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        EngineSound = GameObject.Find("EngineSoundObject").GetComponent<AudioSource>();
        EngineSound.Play();
        rb = GetComponent<Rigidbody>();
        hp = GetComponent<PlayerHPScript>();
        i = this;
    }

    // Update is called once per frame
    void Update()
    {

        Dead = hp.dead;
        switch (activeControls)
        {
            case ActiveControls.FullControllOn:
                StartCoroutine(DropMine(MinePrefab, MineDropPoint, 0.5f));
                MoveTank();
                ps.DisableShoot = false;
                break;
            case ActiveControls.MovementOff_WeponsOn:
                StartCoroutine( DropMine(MinePrefab, MineDropPoint, 0.5f));
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
    }

    private IEnumerator DropMine(GameObject Mine, Transform dropPoint, float reloadTimer)
    {
        Debug.Log(Mine, dropPoint);
        yield return new WaitForSeconds(reloadTimer);
        if (Input.GetButtonDown("DropMine_" + Player.ToString()))
        {
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

    
    public enum ActiveControls
    {
        FullControllOn,
        MovementOff_WeponsOn,
        FullControllOff
    }

}

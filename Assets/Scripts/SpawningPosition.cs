using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPosition : MonoBehaviour
{
    private float coolDown;
    public float coolDownTimer;
    public GameObject repairKit;
    public GameObject speedBoost;
    public GameObject[] PickUps;
    GameObject[] RepairKits;
    public GameObject RepairKit;
    public float spawnRange;
    bool hasObject;

    void Start()
    {
        coolDown = coolDownTimer;
    }

    void Update()
    {
        RepairKits = GameObject.FindGameObjectsWithTag("PickUp");
        float Distance = float.MaxValue;
        foreach (var pickup in RepairKits)
        {
            if (Distance > Vector3.Distance(transform.position, pickup.transform.position))
            {
                Distance = Vector3.Distance(transform.position, pickup.transform.position);
                RepairKit = pickup;
            }
            else if (Distance < Vector3.Distance(transform.position, pickup.transform.position))
            {
                return;
            }
        }
        if (GameObject.FindGameObjectWithTag("PickUp") == null)
        {
            hasObject = false;
        }
        else if (Vector3.Distance(transform.position, RepairKit.transform.position) > spawnRange)
        {
            hasObject = false;

        }
        if (coolDown <= 0)
        {
            Instantiate(PickUps[Random.Range(0, PickUps.Length)], transform.position, Quaternion.identity);
            coolDown = coolDownTimer;
            hasObject = true;
        }
        if (hasObject == false)
        {
            coolDown -= Time.deltaTime;
        }
    }
}

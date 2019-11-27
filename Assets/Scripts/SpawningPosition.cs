using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPosition : MonoBehaviour
{
    private float coolDown;
    public float coolDownTimer;
    public GameObject repairKit;
    public float SpawBRange;
    GameObject _clone;
    bool hasObject;

    void Start()
    {
        coolDown = coolDownTimer;
    }


    void Update()
    {

        if (coolDown <= 0)
        {
            Instantiate(repairKit, transform.position, Quaternion.identity);
            coolDown = coolDownTimer;
            hasObject = true;
        }
        //if (Vector3.Distance(transform.position))
        if (hasObject == false)
        {
            coolDown -= Time.deltaTime;
        }
    }
}

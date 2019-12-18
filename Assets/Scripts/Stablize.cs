using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stablize : MonoBehaviour
{
    Transform head;
    // Start is called before the first frame update
    void Start()
    {
        head = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(head.forward);
        transform.rotation = Quaternion.LookRotation(transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);

    }
}

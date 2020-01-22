using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Application.q
    }

    public void OnMouseEnter()
    {
        Debug.Log("enter");
        transform.localScale += new Vector3(1.1F, 1.1f, 1.1f);
    }

    public void OnMouseExit()
    {
        transform.localScale += new Vector3(1, 1, 1);
    }
}

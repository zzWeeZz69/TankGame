using UnityEngine;
using System;
using System.Diagnostics;


public class SimpleCameraController : MonoBehaviour
{
    
    private void Awake()
    {
        
    }

    

    public static float getDistanceBetween(GameObject gameobject1, GameObject gameobject2)
    {
        return Vector3.Distance(gameobject1.transform.position, gameobject2.transform.position);
    }
    public static float getDistanceBetween(Transform Transform1, Transform Transform2)
    {
        return Vector3.Distance(Transform1.position, Transform2.position);
    }
}
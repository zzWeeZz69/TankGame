using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.25f;
    public float slowdownLength = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.F)) //hold F, time will slow down by 4x times
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else //after release F, time will back to normal in 2 sec
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }
}

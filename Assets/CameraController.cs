﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float SmoothTime;
    [SerializeField] List<Transform> Players;
    [SerializeField] float MinZoom, MaxZoom;
    [SerializeField] Transform CameraPivot;

    private Vector3 velocity;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Zoom();
        move();
    }

    private void Zoom()
    {
        float distance = 0;
        if (Players.Count > 1)
            distance = Vector3.Distance(Players[0].position, Players[1].position);
        Camera.main.orthographicSize = Mathf.Clamp(distance/2, MinZoom, MaxZoom)/1.5f;

    }

    private void move()
    {
        Vector3 CameraPoint = findCenterPoint();
        CameraPivot.position = Vector3.SmoothDamp(CameraPivot.position, CameraPoint, ref velocity, SmoothTime);
        Camera.main.transform.LookAt(CameraPoint);
    }

    Vector3 findCenterPoint()
    {
        if (Players.Count == 1)
        {
            return Players[0].position;
        }

        var bounds = new Bounds(Players[0].position, Vector3.zero);
        for (int i = 0; i < Players.Count; i++)
        {
            bounds.Encapsulate(Players[i].position);
        }
        return bounds.center;
    }
}
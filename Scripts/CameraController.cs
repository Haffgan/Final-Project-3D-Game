﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Joystick joystick;

    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;
    public float yawSpeed = 100f;

    public float currentYaw = 0f;
    private float currentZoom = 10f;

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        currentZoom -= joystick.Vertical * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= joystick.Horizontal * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
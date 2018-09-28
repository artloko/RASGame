using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera cam;
    
    public Transform CameraFollowObj;
    private Transform CamTransform;
    private float currDistance = 5.0f;
    private float clampAngle_MAX = 80.0f;
    private float clampAngle_MIN = -30.0f;
    private float minZoom = 2.0f;
    private float maxZoom = 15.0f;
    private float finalInputX;
    private float finalInputY;
    public float sensivity = 50.0f;

    void Start()
    {
        CamTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            finalInputX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            finalInputY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
            finalInputY = Mathf.Clamp(finalInputY, clampAngle_MIN, clampAngle_MAX);
        }
        currDistance += Input.GetAxis("Mouse ScrollWheel") * sensivity * Time.deltaTime * 10;
        currDistance = Mathf.Clamp(currDistance, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -currDistance);
        Quaternion rotation = Quaternion.Euler(finalInputY, finalInputX, 0);
        CamTransform.position = CameraFollowObj.position + rotation * dir;
        CamTransform.LookAt(CameraFollowObj.position);
    }
}
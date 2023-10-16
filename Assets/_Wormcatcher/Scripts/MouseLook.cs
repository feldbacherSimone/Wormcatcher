﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [SerializeField] private float mouseSensitivity = 1;

    [SerializeField] private Transform playerBody;

    private float xRoation = 0; 

    // Start is called before the first frame update
    void Start()
    {
        if (playerBody == null)
        {
            playerBody = transform.parent; 
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse inputs 
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // up/down rotation 
        xRoation -= mouseY;
        xRoation = Mathf.Clamp(xRoation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRoation, 0f, 0f);
        
        // left/right rotation
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
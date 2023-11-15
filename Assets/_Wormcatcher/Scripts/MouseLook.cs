using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private InputAction mouseMovement; 
    private float mouseX;
    private float mouseY;
    private PlayerInputAction playerInputAction; 

    [SerializeField] private float mouseSensitivity = 1;

    [SerializeField] private Transform playerBody;

    private float xRoation = 0; 

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.WalkInput.Enable();
        mouseMovement = playerInputAction.WalkInput.MouseLook; 
    }

    void Start()
    {
        if (playerBody == null)
        {
            playerBody = transform.parent; 
        }
        //Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            //print(Cursor.lockState);
            // get mouse inputs 
            mouseX = mouseMovement.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
            mouseY = mouseMovement.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;

            // up/down rotation 
            xRoation -= mouseY;
            xRoation = Mathf.Clamp(xRoation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRoation, 0f, 0f);

            // left/right rotation
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}

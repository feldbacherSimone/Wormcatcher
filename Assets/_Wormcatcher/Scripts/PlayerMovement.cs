using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Input 
    private PlayerInputAction playerInputAction;
    private InputAction sprintAction;
    private InputAction movementAction; 
    
    
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    
    private float xInput;
    private float zInput;
    
    // Movement Parameters 
    [SerializeField] private float baseSpeed = 2f;
    [SerializeField] private float targetSpeed;
    [SerializeField]private float currentSpeed; 
    [SerializeField] private float gravity = -9.81f;

    // Collision
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 velocity;
    [SerializeField]private bool isGrounded;
    
    [SerializeField] private float decelerationRate = 5f;
    [SerializeField] private float accelerationRate = 3f;

   

    private void Awake()
    {
        playerInputAction = new PlayerInputAction(); 
        playerInputAction.WalkInput.Enable();
        sprintAction = playerInputAction.WalkInput.Sprint;
        movementAction = playerInputAction.WalkInput.Movement;
    }

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2;

        Boolean sprintInput = sprintAction.ReadValue<float>() != 0;
        
        currentSpeed = sprintInput ? Mathf.Clamp((currentSpeed += (accelerationRate*Time.deltaTime)), 0, targetSpeed) : 
            Mathf.Clamp((currentSpeed -= (decelerationRate*Time.deltaTime)), baseSpeed, targetSpeed);

        xInput = movementAction.ReadValue<Vector2>().x;
        zInput = movementAction.ReadValue<Vector2>().y;
        
        //print(xInput + " " + zInput);
        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

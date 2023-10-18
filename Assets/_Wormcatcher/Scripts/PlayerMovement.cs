using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    
    private float xInput;
    private float zInput;
    private bool sprintInput;
    
    
    [SerializeField] private float baseSpeed = 2f;
    [SerializeField] private float targetSpeed;
    [SerializeField]private float currentSpeed; 
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 velocity;
    [SerializeField]private bool isGrounded;
    
    [SerializeField] private float decelerationRate = 5f;
    [SerializeField] private float accelerationRate = 3f;

    // Start is called before the first frame update
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

        sprintInput = Input.GetKey(KeyCode.LeftShift);
        
        currentSpeed = sprintInput ? Mathf.Clamp((currentSpeed += (accelerationRate*Time.deltaTime)), 0, targetSpeed) : 
            Mathf.Clamp((currentSpeed -= (decelerationRate*Time.deltaTime)), baseSpeed, targetSpeed); 
        
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

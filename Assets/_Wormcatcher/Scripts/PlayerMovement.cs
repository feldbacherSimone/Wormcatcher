using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xInput;
    private float zInput;
    [SerializeField] private float speed;
    
    [SerializeField] CharacterController controller;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(move * speed * Time.deltaTime);
    }
}

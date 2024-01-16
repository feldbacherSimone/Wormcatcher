using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTarget : MonoBehaviour
{
    [Range(0, 10)]
    public float strength = 10;
    public float yOffset = 0;
    public float xOffset = 0;
    public float zDepth = -2;
    Vector3 initPos;
    public bool camera; 
    
    private PlayerInputAction playerInputAction; 
    private InputAction mouseMovement; 
    private InputAction mouseScroll; 
    
    [SerializeField] float minDepth = -10;
    [SerializeField] float maxDepth = 4;
    private void Start()
    {
        initPos = gameObject.transform.position; 
        playerInputAction = new PlayerInputAction();
        playerInputAction.WalkInput.Enable();
        mouseMovement = playerInputAction.WalkInput.MousePosition;
        mouseScroll = playerInputAction.WalkInput.MenuZoom;
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }
    void moveCameraTarget()
    {
        // print(Input.mousePosition);
        
        
        float mouseX = mouseMovement.ReadValue<Vector2>().x ;
        float mouseY = mouseMovement.ReadValue<Vector2>().y ;
        float realitveMouseX = mouseX / Screen.width  - 0.5f + xOffset;
        float realitveMouseY = mouseY / Screen.height - 0.5f + yOffset;

        if (camera)
        {
            
            if (zDepth >= minDepth && zDepth <= maxDepth)
            {
                zDepth += mouseScroll.ReadValue<Vector2>().y/1000;
                //print("mouse Scroll: " + Input.mouseScrollDelta.y);
            }
            else if (zDepth < minDepth)
            {
                zDepth = minDepth;
            }
            else if (zDepth > maxDepth)
            {
                zDepth = maxDepth;
            }
        }
        

        Vector3 newPos = new Vector3(initPos.x + realitveMouseX * strength, initPos.y + realitveMouseY * strength, zDepth);



        gameObject.transform.position = newPos;
        
        // gameObject.transform.position = new Vector3(pos.x, pos.y, -2);

    }

    private void Update()
    {
        moveCameraTarget();
    }


    
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace _Wormcatcher.Scripts.Inputs
{
    /// <summary>
    /// Rotates player based on mouse delta 
    /// </summary>
    public class MouseLook : MonoBehaviour
    {
        private InputAction mouseMovement; 
        private InputAction mousePosition; 
        private float mouseX;
        private float mouseY;
        private PlayerInputAction playerInputAction; 

        [SerializeField] private float mouseSensitivity = 1;

        [SerializeField] private Transform playerBody;

        private float xRoation = 0; 

        private void Awake()
        {
            playerInputAction = new PlayerInputAction();
            playerInputAction.WalkInput.Enable();
            mouseMovement = playerInputAction.WalkInput.MouseLook;
            mousePosition = playerInputAction.WalkInput.MousePosition;
        }

        void Start()
        {
            if (playerBody == null)
            {
                playerBody = transform.parent; 
            }
 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void Update()
        {
            if (true)
            {
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
}

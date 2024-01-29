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

        [SerializeField] private float initRotation;

        [SerializeField] private bool limitLookAngle;
        [SerializeField] float lookAngle;
        public float[] MouseSensitivityBounds => mouseSensitivityBounds;

        [SerializeField] private float[] mouseSensitivityBounds = { 10, 80 };
        [SerializeField] private float mouseSensitivity = 25;

        
        private Quaternion lastRotation;

        public void SetLookAngle(float angle, float initRotation)
        {
            limitLookAngle = true;
            this.initRotation = initRotation; 
            lookAngle = angle;
        }
        public float MouseSensitivity
        {
            get => mouseSensitivity;
            set => mouseSensitivity = value;
        }

        [SerializeField] private bool smoothMovement = false;
        private float xAccumulator = 1;
        private float yAccumulator = 1;
        [SerializeField] private float snappiness = 10;

        [SerializeField] private Transform playerBody;

        private float xRoation = 0;

        private void Awake()
        {
            initRotation = playerBody.rotation.eulerAngles.y;


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
            lastRotation = playerBody.rotation; 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
           // print(playerBody.rotation.eulerAngles.y);

           
            lastRotation = playerBody.rotation; 
            if (true)
            {
                // get mouse inputs 
                mouseX = mouseMovement.ReadValue<Vector2>().x * mouseSensitivity/100;
                mouseY = mouseMovement.ReadValue<Vector2>().y * mouseSensitivity/100;

                if (smoothMovement && Time.timeScale > 0)
                {
                    xAccumulator = Mathf.Lerp(xAccumulator, mouseX, snappiness/100);
                    yAccumulator = Mathf.Lerp(yAccumulator, mouseY, snappiness/100);
                    
                    // up/down rotation 
                    xRoation -= yAccumulator;
                    xRoation = Mathf.Clamp(xRoation, -90f, 90f);
                    transform.localRotation = Quaternion.Euler(xRoation, 0f, 0f);


                    

                    // left/right rotation
                    playerBody.Rotate(Vector3.up * xAccumulator);

                    if (limitLookAngle && (playerBody.rotation.eulerAngles.y > initRotation + lookAngle / 2 ||
                        playerBody.rotation.eulerAngles.y < initRotation - lookAngle / 2))
                    {
                        playerBody.rotation = lastRotation;
                    }
                    
                    return;
                }

                // up/down rotation 
                xRoation -= mouseY;
                xRoation = Mathf.Clamp(xRoation, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRoation, 0f, 0f);

                // left/right rotation
                playerBody.Rotate(Vector3.up * mouseX);
                if (limitLookAngle && (playerBody.rotation.eulerAngles.y > initRotation + lookAngle / 2 ||
                    playerBody.rotation.eulerAngles.y < initRotation - lookAngle / 2))
                {
                    playerBody.rotation = lastRotation;
                }
              
            }
        }
    }
}
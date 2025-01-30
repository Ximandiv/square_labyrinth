using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField]
        private Vector3 moveDirection = Vector3.zero;
        [SerializeField]
        private int speed = 5;
        [SerializeField]
        private float rotationSpeed = 100f;

        private float movement = 0f;
        private float rotation = 0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if(rb is null)
            {
                print("Player's Rigidbody was not found. Game cannot be played like this!");
                return;
            }
        }

        private void Update()
        {
            getInput();
        }

        private void FixedUpdate()
        {
            if (movement == 0f && rotation == 0f)
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                return;
            }

            if (rotation != 0f)
            {
                Quaternion targetRotation = Quaternion.Euler(0, rotation * rotationSpeed * Time.fixedDeltaTime, 0);
                rb.MoveRotation(rb.rotation * targetRotation);
            }

            moveDirection = transform.forward * movement * speed;
            rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        }

        private void getInput()
        {
            movement = Input.GetAxis("Vertical");
            rotation = Input.GetAxis("Horizontal");
        }
    }
}

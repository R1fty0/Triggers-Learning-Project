using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class FPPMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public float gravity = -9.81f;
    public float jumpHeight;
    public KeyCode jumpButton; 

    [Header("References")]
    [Tooltip("The lowest point of the player.")]
    public Transform groundCheck;
    [Tooltip("Layer containing all ground objects.")]
    public LayerMask groundMask;

    #region Private Variables
    CharacterController controller;
    Vector3 currentVelocity;

    #endregion

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Movement();
        Jumping();
    }

    void Movement()
    {
        // Get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction 
        Vector3 movementDirection = transform.right * x + transform.forward * z;

        // Move
        controller.Move(movementDirection * speed * Time.deltaTime);
    }

    void Jumping()
    {
        if (Input.GetKeyDown(jumpButton) && isGrounded())
        {
            // Jump 
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        else if (!isGrounded())
        {
            // Add gravity while player is in the air 
            currentVelocity.y += gravity * Time.deltaTime;
            
        }
        else if (isGrounded() && currentVelocity.y > 0.0f)
        {
            // Reset gravity
            currentVelocity.y = 0.0f;
        }

        // Apply jumping movement 
        controller.Move(currentVelocity * Time.deltaTime);
    }

    private bool isGrounded()
    {
        Debug.DrawRay(groundCheck.position, Vector3.down);
        // Return true if player is on the ground 
        if (Physics.Raycast(groundCheck.position, Vector3.down, 0.25f, groundMask))
        {
            return true;
        }
        // Return false if the player is in the air 
        else
        {
            return false;
        }
    }
}

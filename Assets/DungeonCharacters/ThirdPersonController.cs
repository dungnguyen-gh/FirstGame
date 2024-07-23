using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    private Animator animator;
    private Rigidbody rigidbody;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input from keyboard or gamepad
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Set animation parameters based on input
        animator.SetFloat("Speed", verticalInput);
        animator.SetFloat("Direction", horizontalInput);

        // Rotate the character left or right
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Move the character forward or backward
        rigidbody.MovePosition(transform.position + transform.forward * verticalInput * moveSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded;
    private Transform cam;

    private Vector3 moveDir;
    private bool run;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        cam = Camera.main.transform; 
    }

    void Update()
    {
        // check ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        run = Input.GetKey(KeyCode.LeftShift);

        // camera-based direction
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        forward.y = 0f;
        right.y = 0f;
        moveDir = (forward * v + right * h).normalized;

        // animations
        anim.SetFloat("Speed", moveDir.magnitude);
        anim.SetBool("IsRunning", run);
        anim.SetBool("IsGrounded", isGrounded);

        // jump (in Update for instant response)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // reset Y velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        // move
        if (moveDir.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0, targetAngle, 0);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));

            float speed = run ? runSpeed : moveSpeed;
            Vector3 move = moveDir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }
}

using UnityEngine;

public class MovementScript1 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float standardMoveSpeed = 7f;
    public float sprintMoveSpeed;
    public float gravity = -9.81f;
    public bool moving;

    public float jumpHeight = 3f;

    Vector3 velocity;

    public CharacterController controller;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
        Jump();
        Sprint();

        if(transform.hasChanged != true)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && moving)
        {
            moveSpeed = sprintMoveSpeed;
            Debug.Log("faster");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = standardMoveSpeed;
            Debug.Log("normal");
        }
    }
}

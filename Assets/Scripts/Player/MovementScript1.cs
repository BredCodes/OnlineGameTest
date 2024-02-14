using Photon.Pun;
using UnityEngine;

public class MovementScript1 : MonoBehaviourPun
{
    [Header("Movement")]
    public float standardMoveSpeed = 7f;
    public float sprintMoveSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private float moveSpeed;
    private bool isSprinting = false;

    Vector3 velocity;
    private CharacterController controller;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private CameraScript cameraController;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = standardMoveSpeed;

        // Check if the local player owns this GameObject
        if (photonView.IsMine)
        {
            cameraController = GetComponentInChildren<CameraScript>();
            if (cameraController != null)
                cameraController.enabled = true;
        }
        else
        {
            enabled = false;
            cameraController = GetComponentInChildren<CameraScript>();
            if (cameraController != null)
                cameraController.enabled = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (!photonView.IsMine)
            return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight* -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isSprinting)
        {
            isSprinting = true;
            moveSpeed = sprintMoveSpeed;
            Debug.Log("Sprinting");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || !isGrounded)
        {
            isSprinting = false;
            moveSpeed = standardMoveSpeed;
            Debug.Log("Walking");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

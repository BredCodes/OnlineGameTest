using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //sensitivity
    public float mouseSensitivity = 100f;

    //components
    public Transform playerBody;

    //rotation
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //make cursor invisible and not move from the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Input of the mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

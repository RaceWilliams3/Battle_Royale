using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Clamping")]
    public float minY;
    public float maxY;

    [Header("Spectator")]
    public float spectatorMoveSpeed;

    private float rotX;
    private float rotY;

    private bool isSpectator = false;

    void Start()
    {
        //Lock the cursor in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //Get the mouse movement inputs
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        //Clamp the vertical rotation
        rotY = Mathf.Clamp(rotY, minY, maxY);

        //are we spectating
        if(isSpectator)
        {
            // rotate the cam vertically
            transform.rotation = Quaternion.Euler(-rotY, rotX, 0);

            // movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;

            if(Input.GetKey(KeyCode.E))
            {
                y = 1;
            } else if (Input.GetKey(KeyCode.Q))
            {
                y = -1;
            }

            Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
            transform.position += dir * spectatorMoveSpeed * Time.deltaTime;
        } 
        else
        {
            // rotate the camera vertically
            transform.localRotation = Quaternion.Euler(-rotY, 0, 0);

            //rotate the player horizontally
            transform.parent.rotation = Quaternion.Euler(0, rotX, 0);
        }
    }
}


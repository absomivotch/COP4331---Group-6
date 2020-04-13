using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraMovement : MonoBehaviour
{
	
    public float moveSpeed = 10.0f;
    public float scrollSpeed = 10.0f;

    float horizontalInput;
    float verticalInput;
    float wheelInput;

    float cameraX;
    float cameraY;
    float cameraZ;


    void Update () {
    	
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        wheelInput = Input.GetAxis("Mouse ScrollWheel");
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || verticalInput != 0) {
            transform.position += moveSpeed * new Vector3(horizontalInput, 0, verticalInput);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }


    }
}

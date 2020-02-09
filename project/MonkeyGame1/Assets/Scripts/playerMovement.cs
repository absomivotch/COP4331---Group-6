using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = 10.0f;
    }

    void OnCollisionEnter (Collision collision)
 	{
     if (collision.gameObject.tag == "Wall")
     {
         Debug.Log("COLLISION");
     }
 	}

    void Update()
    {
        transform.Translate(
        	Input.GetAxis("Horizontal") *
        		Time.deltaTime *
        		speed, 
      		0f, 
      		Input.GetAxis("Vertical") *
      			Time.deltaTime *
      			speed
      	);

    }
}

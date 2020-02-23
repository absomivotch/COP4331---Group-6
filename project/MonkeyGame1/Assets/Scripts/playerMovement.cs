using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private const float normalSpeed = 10f;
    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
            MoveHorizontally(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Vertical"))
            MoveVertically(Input.GetAxis("Vertical"));
    }

    private void MoveHorizontally(float value)
    {
        float deltaX = Time.fixedDeltaTime * value * normalSpeed;
        TransformPosition(deltaX, 0f);
    }

    private void MoveVertically(float value)
    {
        float deltaY = Time.fixedDeltaTime * value * normalSpeed;
        TransformPosition(0f, deltaY);
    }

    private void TransformPosition(float deltaX, float deltaY)
    {
        transform.Translate(deltaX, 0f, deltaY);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("COLLISION");
        }
    }
}

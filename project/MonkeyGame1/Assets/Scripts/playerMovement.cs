using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed = 10;

    public Vector3 Calculate(float h, float v, float deltaTime)
    {
        var x = h * Speed * deltaTime;
        var z = v * Speed * deltaTime;
        return new Vector3(-x, 0, -z);
    }

    private void Update()
    {
        transform.position = transform.position + Calculate(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            Time.deltaTime) * -1;
    }
}
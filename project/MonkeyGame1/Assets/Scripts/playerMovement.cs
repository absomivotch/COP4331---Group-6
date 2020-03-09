using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed = 10;
    public Movement Movement;
    private void Start()
    {
        Movement = new Movement(Speed);
    }

    private void Update()
    {
        transform.position = transform.position + Movement.Calculate(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            Time.deltaTime)*-1;
    }
}
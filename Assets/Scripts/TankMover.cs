using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    // Variable to hold the Rigidbody Component
    private Rigidbody rb;

    // Variable to hold the transform component
    private Transform tf;

    // Start is called before the first frame update

    public override void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Get the Transform component
        tf = gameObject.transform;

    }

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;

        rb.MovePosition(rb.position + moveVector);
    }

    public override void Rotate(float turnSpeed)
    {
        tf.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}

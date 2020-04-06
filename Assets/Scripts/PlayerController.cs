using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAccel;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CalibrateThePlayerRotation();
    }

    void FixedUpdate()
    {
        AddForceToThePlayer();
        RotateThePlayer();
    }

    private void CalibrateThePlayerRotation() {
        xAccel = Input.acceleration.x;
    }

    private void AddForceToThePlayer() {
        rb.AddForce(transform.forward * 3);
    }

    private void RotateThePlayer() {
        if (Input.acceleration.x - xAccel > 0.1f) {
            transform.Rotate(0, 1f, 0);
        }
        else if (Input.acceleration.x - xAccel > 0.7f) {
            transform.Rotate(0, 4f, 0);
        }
        else if (Input.acceleration.x - xAccel > 0.8f)
        {
            transform.Rotate(0, 6f, 0);
        }
        else if (Input.acceleration.x - xAccel < -0.1f)
        {
            transform.Rotate(0, -1f, 0);
        }
        else if (Input.acceleration.x - xAccel < -0.7f)
        {
            transform.Rotate(0, -4f, 0);
        }
        else if (Input.acceleration.x - xAccel < -0.8f)
        {
            transform.Rotate(0, -6f, 0);
        }
    }
}

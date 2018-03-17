using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float movementSpeed;


    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey("a"))
        {
            myRigidbody.velocity = -transform.right * movementSpeed;
        }
        if (Input.GetKey("d"))
        {
            myRigidbody.velocity = transform.right * movementSpeed;
        }
        if (Input.GetKey("w"))
        {
            myRigidbody.velocity = transform.up * movementSpeed;
        }
        if (Input.GetKey("s"))
        {
            myRigidbody.velocity = -transform.up * movementSpeed;
        }
    }
}

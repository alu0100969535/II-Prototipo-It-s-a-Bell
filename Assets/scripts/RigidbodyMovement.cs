using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public float movementSpeed = 1000.0f;
    public float rotationSpeed = 100.0f;
    public float jumpSpeed = 1000.0f;

    //Axis - configure in Unity > Exit > Project Settings
    public string verticalAxisName = "Vertical";
    public string horizontalAxisName = "Horizontal";
    //Values
    public float VerticalAxis;
    public float HorizontalAxis;
    public float ZAxis;

    public Rigidbody rigidbody;

    //Movimiento de un objeto rígido usado para testeo en fases tempranas de desarrollo

    void Start() {
      rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update() {

        VerticalAxis = Input.GetAxis(verticalAxisName);
        HorizontalAxis = Input.GetAxis(horizontalAxisName);
        ZAxis = Input.GetButton("Jump") ? 1 : 0;
        /*  Vertical axis: W-S (Forward, backward)
         *  Horizontal axis: A-D (Left, Right)
         */
        float vertical = VerticalAxis * movementSpeed * Time.deltaTime;
        float horizontal = HorizontalAxis * movementSpeed * Time.deltaTime;
        float z = ZAxis * jumpSpeed * Time.deltaTime;
        
        rigidbody.AddRelativeForce(horizontal, z, vertical);

    }
}
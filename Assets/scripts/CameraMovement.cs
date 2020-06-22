using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100.0f;

    //Axis - configure in Unity > Exit > Project Settings
    public string verticalAxisName = "Vertical";
    public string horizontalAxisName = "Horizontal";
    //Values
    public float VerticalAxis;
    public float HorizontalAxis;

   /* void Start()
    {
    }*/
    // Update is called once per frame
    void Update()
    {
        VerticalAxis = Input.GetAxis(verticalAxisName);
        HorizontalAxis = Input.GetAxis(horizontalAxisName);
        /*  Vertical axis: W-S (Forward, backward)
         *  Horizontal axis: A-D (Left, Right)
         */
        float vertical = VerticalAxis * movementSpeed * Time.deltaTime;
        float horizontal = HorizontalAxis * movementSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, vertical);

        /*  For rotation we consider Q and E to rotate from vertical axis (y);
         *  Q for Left rotation and E for Right rotation.
         *  Both pressed at the same time equals to 0 degree rotation
         */
        float rotationLeft = Input.GetKey(KeyCode.Q) ? -rotationSpeed * Time.deltaTime : 0;
        float rotationRight = Input.GetKey(KeyCode.E) ? rotationSpeed * Time.deltaTime : 0;
        float rotationTotal = rotationLeft + rotationRight;

        this.transform.Rotate(0, rotationTotal, 0);

    }
}
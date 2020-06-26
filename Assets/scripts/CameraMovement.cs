using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public float sensitivity = 500.0f;
  
  public GameObject player;
  Rigidbody m_Rigidbody; 
  
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        m_Rigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        float speed = rotateHorizontal * sensitivity * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, speed, 0));
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }
}

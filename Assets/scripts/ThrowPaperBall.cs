using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPaperBall : MonoBehaviour
{

    public float thrust = 30.0f;
    private Rigidbody ballRigidBody;
    public GameObject originalBall;

    public float xOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Bola que se va a clonar para lanzarse
        originalBall = GameObject.Find("paper_low");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform transf = GetComponent<Transform>();

            // Copia de la bola que se crea en frente del protagonista
            GameObject newBall = Instantiate(originalBall, new Vector3(transf.position.x + xOffset + 0.4f * Mathf.Sin(transf.rotation.eulerAngles.y * Mathf.Deg2Rad), transf.position.y + 0.8f, transf.position.z + 0.4f * Mathf.Cos(transf.rotation.eulerAngles.y * Mathf.Deg2Rad)), Quaternion.identity);

            ballRigidBody = newBall.GetComponent<Rigidbody>();

            // Lanzamiento de la bola hacia donde mira el personaje

            float direccionX = Mathf.Sin(transf.rotation.eulerAngles.y * Mathf.Deg2Rad);
            float direccionZ = Mathf.Cos(transf.rotation.eulerAngles.y * Mathf.Deg2Rad);

            ballRigidBody.AddForce(thrust * direccionX, 0, thrust * direccionZ, ForceMode.Impulse);
        }
    }
}

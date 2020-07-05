using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{

    public float thrust = 30.0f;
    private Rigidbody ballRigidBody;
    public GameObject objectPrefab;

    private Animator anim;

    public float distanciaAlCuerpo = 0.4f;
    public float alturaDesdeSuelo = 0.8f;
    public float xOffset = 0.5f;

    public float secondsUntilThrow = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform transf = GetComponent<Transform>();

            // Copia de la bola que se crea en frente del protagonista
            

            anim.SetTrigger("Throwing");
            StartCoroutine(wait(secondsUntilThrow,transf));
        }
    }

    IEnumerator wait(float seconds,Transform origen)
    {
        yield return new WaitForSeconds(seconds);
        GameObject newBall = Instantiate(objectPrefab, new Vector3(origen.position.x +  distanciaAlCuerpo * Mathf.Sin(origen.rotation.eulerAngles.y * Mathf.Deg2Rad), origen.position.y + alturaDesdeSuelo, origen.position.z + distanciaAlCuerpo * Mathf.Cos(origen.rotation.eulerAngles.y * Mathf.Deg2Rad)), Quaternion.identity);
        newBall.transform.Translate(new Vector3(xOffset, 0, 0));
        ballRigidBody = newBall.GetComponent<Rigidbody>();

        // Lanzamiento de la bola hacia donde mira el personaje

        float direccionX = Mathf.Sin(origen.rotation.eulerAngles.y * Mathf.Deg2Rad);
        float direccionZ = Mathf.Cos(origen.rotation.eulerAngles.y * Mathf.Deg2Rad);
        ballRigidBody.AddForce(thrust * direccionX, 0, thrust * direccionZ, ForceMode.Impulse);

    }
}

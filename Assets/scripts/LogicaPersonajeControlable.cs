using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonajeControlable : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f;
    public float velocidadGiro = 200.0f;
    private Animator anim;
    public float HorizontalAxis;
    public float VerticalAxis;
    public GameObject camera;
    public GameObject cameraRig;

    public float alturaCamara = 0.79f;
    public float distanciaAlCuerpo = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        // Guardamos lo registrado en las teclas AD en la variable 'HorizontalAxis' que toma valores -1, 0 o 1 
        // dependiendo de cual pulsemos o si no pulsamos ninguna y lo  mismo con la variable 'VerticalAxis' 
        // con las teclas WS.
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");

        // Rotamos dependiendo de como rote la cámara de realidad virtual.

        if(camera!=null)
            transform.eulerAngles = new Vector3(0,camera.transform.eulerAngles.y,0);

        //Definimos las velocidades de movimiento para cada eje

        float vertical = VerticalAxis * velocidadMovimiento * Time.deltaTime;
        float horizontal = HorizontalAxis * velocidadMovimiento * Time.deltaTime;
        float z = 0;

        GetComponent<Rigidbody>().AddRelativeForce(horizontal, z, vertical);

        //Movemos la cámara al mismo punto al que se mueve el personaje

        cameraRig.transform.position = new Vector3(transform.position.x + distanciaAlCuerpo * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad), transform.position.y + alturaCamara, transform.position.z + distanciaAlCuerpo * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad));

        // Enviamos las variables al animador para ver que animación ejecutar.
        anim.SetFloat("VelX", HorizontalAxis);
        anim.SetFloat("VelY", VerticalAxis);
    }

    
}

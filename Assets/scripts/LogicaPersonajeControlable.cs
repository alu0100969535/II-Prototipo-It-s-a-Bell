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

        // Guardamos lo registrado en las teclas AD en la variable 'x' que toma valores -1, 0 o 1 
        // dependiendo de cual pulsemos o si no pulsamos ninguna y lo  mismo con la variable 'y' 
        // con las teclas WS.
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");

        // Rotamos dependiendo de la variable x en el eje y de rotación y avanzamos dependiendo 
        // de la variable y en el eje z de posición.
        //transform.Rotate(0, x * Time.deltaTime * velocidadGiro, 0);
        //Quaternion rotateTo = new Quaternion(0,camera.transform.rotation.y,0,camera.transform.rotation.w);
        //transform.Rotate(0,rotateTo.y-transform.rotation.y,0);

        if(camera!=null)
            transform.eulerAngles = new Vector3(0,camera.transform.eulerAngles.y,0);

        //camera.transform.rotation = new Quaternion(0, 0, 0, 1);
        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        /*
        
        GetComponent<Rigidbody>().AddForce(y * Time.deltaTime * velocidadMovimiento * direccionX, 0, y * Time.deltaTime * velocidadMovimiento * direccionZ, ForceMode.Impulse);

        float direccionXSideways = Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        float direccionZSideways = Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        GetComponent<Rigidbody>().AddForce(x * Time.deltaTime * velocidadMovimiento * direccionX, 0, x * Time.deltaTime * velocidadMovimiento * direccionZ, ForceMode.Impulse);
        */
        float vertical = VerticalAxis * velocidadMovimiento * Time.deltaTime;
        float horizontal = HorizontalAxis * velocidadMovimiento * Time.deltaTime;
        float z = 0;
        //this.transform.Translate(horizontal, 0, vertical);
        GetComponent<Rigidbody>().AddRelativeForce(horizontal, z, vertical);

        camera.transform.position = new Vector3(transform.position.x + distanciaAlCuerpo * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad), transform.position.y + alturaCamara, transform.position.z + distanciaAlCuerpo * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
        //GetComponent<Rigidbody>().AddForce(velocidadMovimiento * direccionX, 0, velocidadMovimiento * direccionZ, ForceMode.Impulse);

        // Enviamos las variables x e y al animador para ver que animación ejecutar.
        anim.SetFloat("VelX", HorizontalAxis);
        anim.SetFloat("VelY", VerticalAxis);
    }

    
}

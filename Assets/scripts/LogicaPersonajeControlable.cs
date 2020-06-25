using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonajeControlable : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadGiro = 200.0f;
    private Animator anim;
    public float x;
    public float y;

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
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotamos dependiendo de la variable x en el eje y de rotación y avanzamos dependiendo 
        // de la variable y en el eje z de posición.
        transform.Rotate(0, x * Time.deltaTime * velocidadGiro, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        // Enviamos las variables x e y al animador para ver que animación ejecutar.
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}

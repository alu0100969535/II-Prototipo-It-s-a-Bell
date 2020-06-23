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
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadGiro, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}

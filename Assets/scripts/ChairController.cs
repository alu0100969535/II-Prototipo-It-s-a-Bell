using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    private bool isIn = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.controller.eventHandler += onChairInteraction;
        animator = GetComponent<Animator>();
    }

    //Ejecuta la animación necessaria dependiendo de si pone la silla en su sitio o la echa atrás
    // si es el target indicado
    private void onChairInteraction(GameObject target) {
        if(target == gameObject) {
            isIn = !isIn;
            animator.Play(isIn ? "chairIn" : "chairOut");
        }
    }

    //Ejecuta la animación necessaria dependiendo de si pone la silla en su sitio o la echa atrás
    public void onChairInteraction() {
        isIn = !isIn;
        animator.Play(isIn ? "chairIn" : "chairOut");
    }
}

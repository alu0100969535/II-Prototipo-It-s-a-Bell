using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private bool isOpen = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.controller.eventHandler += onDoorInteraction;
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    //Ejecuta la animación necessaria dependiendo de si pone la puerta en su sitio o la abre
    // si es el target indicado
    private void onDoorInteraction(GameObject target) {
        if(target == gameObject) {
            isOpen = !isOpen;
            animator.Play(isOpen ? "open" : "close");    
        }
    }

    //Ejecuta la animación necessaria dependiendo de si pone la puerta en su sitio o la abre
    public void onDoorInteraction() {
        isOpen = !isOpen;
        animator.Play(isOpen ? "open" : "close");    
    }
}

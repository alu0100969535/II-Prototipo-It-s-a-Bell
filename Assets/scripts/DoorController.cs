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

    private void onDoorInteraction(GameObject target) {
        if(target == gameObject) {
            isOpen = !isOpen;
            animator.Play(isOpen ? "open" : "close");    
        }
    }
    public void onDoorInteraction() {
        isOpen = !isOpen;
        animator.Play(isOpen ? "open" : "close");    
    }
}

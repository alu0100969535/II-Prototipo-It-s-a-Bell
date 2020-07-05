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
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    public void onDoorInteraction() {
        isOpen = !isOpen;
        animator.Play(isOpen ? "open" : "close");    
    }
}

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

    private void onChairInteraction(GameObject target) {
        if(target == gameObject) {
            isIn = !isIn;
            animator.Play(isIn ? "chairIn" : "chairOut");
        }
    }
}

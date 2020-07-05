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
        animator = GetComponent<Animator>();
    }

    public void onChairInteraction() {
        isIn = !isIn;
        animator.Play(isIn ? "chairIn" : "chairOut");
    }
}

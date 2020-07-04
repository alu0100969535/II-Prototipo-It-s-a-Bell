using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTeacher : MonoBehaviour
{

    private Animator anim;
    public bool facingBoard = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        facingBoard = anim.GetBool("Rotate");
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, 5);
        if (rnd == 0)
        {
            anim.SetTrigger("Rotate");
        }
        if (anim.GetBool("Rotate"))
        {
            anim.SetTrigger("Rotate");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTeacher : MonoBehaviour
{

    private Animator anim;
    public bool facingBoard = true;
    private bool rotating = false;
    public float secondsToWait = 2.0f;
    public float probabilityToRotateEveryFrame = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        facingBoard = anim.GetBool("Rotate");
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating)
        {
            int rnd = Random.Range(0, 500);
            Debug.Log("rnd " + rnd);
            if (rnd == 0)
            {
                anim.SetTrigger("Rotate");
                rotating = true;
                StartCoroutine(wait(secondsToWait));
            }
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        rotating = false;
    }
}

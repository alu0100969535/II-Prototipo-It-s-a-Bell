using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTeacher : MonoBehaviour
{

    private Animator anim;
    public bool facingBoard = true;
    public float secondsToWait = 1.0f;
    public float probabilityToRotateEverySecond = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(wait(secondsToWait));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator wait(float seconds)
    {
        while (true)
        {
            int rnd = Random.Range(0, (int)(1f / probabilityToRotateEverySecond));
            if (rnd == 0)
            {
                anim.SetTrigger("Rotate");
                facingBoard = !(facingBoard);
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(1);
        }
    }
}

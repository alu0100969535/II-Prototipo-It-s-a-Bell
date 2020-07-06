using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{

    public ParticleSystem hit;
    public GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<ParticleSystem>();
        g = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            hit.Play();
        }
    }
}

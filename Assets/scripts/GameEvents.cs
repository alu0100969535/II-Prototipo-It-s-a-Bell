using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents controller;
    public delegate void raycastHitCheck(GameObject target);
	public event raycastHitCheck eventHandler;

    public float maxDistance = 3.0f;

    // Delegado usado para saber a que objeto mira la retícula e interactuar con ese objeto

    private void Awake() {
        if(controller == null){
            controller = this;
			DontDestroyOnLoad(this);
		}		
		else if(controller != this){
			Destroy(this);
		}
    }

    void Update()
    {
        if(Input.GetButtonDown("Use Key")) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                GameObject target = hit.transform.gameObject;
                eventHandler(target);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }
    }
}

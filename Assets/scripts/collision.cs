using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    //Código usado para debugear usado en la fase de desarrollo

    public GameObject g;
    // Start is called before the first frame update
    void Start() {
        g = gameObject;
    }

    void OnCollisionEnter(Collision collision) {
      string message = g.ToString() + " OnCollisionEnter";
      Debug.Log(message);
    }

    void OnCollisionStay(Collision collision) {
      string message = g.ToString() + " OnCollisionStay";
      Debug.Log(message);
    }

    void OnCollisionExit(Collision collision) {
      string message = g.ToString() + " OnCollisionExit";
      Debug.Log(message);
    }
}

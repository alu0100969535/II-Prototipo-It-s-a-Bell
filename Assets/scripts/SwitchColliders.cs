using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColliders : MonoBehaviour
{
    public GameObject childColliderOne;
    public GameObject childColliderTwo;

    //Desactive el collider del primer parámetro y activa el del segundo
    public void switchColliders()
    {
        childColliderOne.SetActive(false);
        childColliderTwo.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColliders : MonoBehaviour
{
    public GameObject childColliderOne;
    public GameObject childColliderTwo;

    public void switchColliders()
    {
        childColliderOne.SetActive(false);
        childColliderTwo.SetActive(true);
    }
}

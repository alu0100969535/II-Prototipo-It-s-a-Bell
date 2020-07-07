using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public GameObject watcher;
    public GameObject player;
    public float damageToPlayer = 1.0f;
    public float invulnerabilitySeconds = 1.0f;
    private bool invulnerable = false;

    public AudioClip sonidoEnfado;
    public AudioClip sonidoCampana;

    private void OnEnable()
    {
        Health.OnDamaged += HandleOnDamaged;

    }

    private void OnDisable()
    {
        Health.OnDamaged -= HandleOnDamaged;
    }

    //Función suscrita al delegado del script Health
    void HandleOnDamaged (GameObject go)
    {
        //Si se ha hecho daño a un objeto mientras la profesora miraba se pierde una vida
        if (!watcher.GetComponent<RotateTeacher>().facingBoard)
        {
            if (!invulnerable)
            {
                invulnerable = true;
                //El jugador cuenta con un rango de invulnerabilidad despues de perder una vida
                StartCoroutine(damagePlayer(invulnerabilitySeconds));
                
            }
        }
    }

    IEnumerator damagePlayer(float invulnerabilitySeconds)
    {
        //El jugador pierde una vida
        player.SendMessage("DamageTaken", damageToPlayer);
        watcher.GetComponent<Animator>().SetTrigger("Angry");

        //Se reproducen los sonidos de enfado de la profesora y de pérdida de vida
        if (sonidoEnfado != null)
            watcher.GetComponent<AudioSource>().PlayOneShot(sonidoEnfado);

        yield return new WaitForSeconds(invulnerabilitySeconds);

        if (sonidoCampana != null)
            player.GetComponent<AudioSource>().PlayOneShot(sonidoCampana);

        invulnerable = false;
    }
}

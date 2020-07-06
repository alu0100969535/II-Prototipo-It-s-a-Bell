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
    void HandleOnDamaged (GameObject go)
    {
        if (!watcher.GetComponent<RotateTeacher>().facingBoard)
        {
            if (!invulnerable)
            {
                invulnerable = true;
                StartCoroutine(damagePlayer(invulnerabilitySeconds));
                
            }
            //player.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(lifeCount.GetComponent<UnityEngine.UI.Text>().text) - 1).ToString();
        }
    }

    IEnumerator damagePlayer(float invulnerabilitySeconds)
    {

        player.SendMessage("DamageTaken", damageToPlayer);
        watcher.GetComponent<Animator>().SetTrigger("Angry");

        if (sonidoEnfado != null)
            watcher.GetComponent<AudioSource>().PlayOneShot(sonidoEnfado);

        yield return new WaitForSeconds(invulnerabilitySeconds);

        if (sonidoCampana != null)
            player.GetComponent<AudioSource>().PlayOneShot(sonidoCampana);

        invulnerable = false;
    }
}

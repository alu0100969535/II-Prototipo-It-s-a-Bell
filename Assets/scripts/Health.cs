using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public delegate void _OnDamaged(GameObject go);
    public static event _OnDamaged OnDamaged;
    public UnityEngine.UI.Text contadorVida;

    public AudioClip damagedSound;

    private Animator anim;
    public UnityEvent OnDead;
    public float currentHealth;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (contadorVida != null)
        {
            actualizarContadorVida();
        }
    }

    void DamageTaken(float amount)
    {
        
        currentHealth -= amount;

        if (damagedSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(damagedSound);
        }


        Debug.Log(gameObject + " vida restante " + currentHealth);

        if (contadorVida != null)
        {
            actualizarContadorVida();
        }


        if (currentHealth == 0)
        {
            anim.SetTrigger("Dead");
            OnDead.Invoke();
        } 

        if(OnDamaged != null)
        {
            OnDamaged(gameObject);
        }
    }

    void actualizarContadorVida()
    {
        contadorVida.text = currentHealth.ToString();
    }
}

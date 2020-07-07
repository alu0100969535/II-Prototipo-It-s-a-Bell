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

        //Si el objeto cuenta con contador de vida se inicializa al principio del juego.
        if (contadorVida != null)
        {
            actualizarContadorVida();
        }
    }

    void DamageTaken(float amount)
    {
        //El objeto pierde vida igual a amount
        currentHealth -= amount;
        //Se reproduce el sonido asignado a perder vida
        if (damagedSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(damagedSound);
        }

        //Si tiene contador se actualiza
        if (contadorVida != null)
        {
            actualizarContadorVida();
        }

        //Si muere se reproducen las animaciones y las funciones asignadas
        if (currentHealth == 0)
        {
            anim.SetTrigger("Dead");
            OnDead.Invoke();
        } 

        //Si hay alguien suscrito al delegado se le notifica
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

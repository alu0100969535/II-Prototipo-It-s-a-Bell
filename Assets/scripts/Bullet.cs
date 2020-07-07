using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 5.0f;

    public float damage = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DestroyBullet(float bulletLifetime)
    {
        Destroy(gameObject, bulletLifetime);
    }

    //Cuando la bala colisiona mira si es un enemigo o no, si lo es desaparece para evitar colisionar 
    //multiples veces y si no lo es se queda unos segundos antes de desaparecer
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("EnemyCollider")) {
            DestroyBullet(0);
            collision.collider.gameObject.transform.parent.SendMessage("DamageTaken", damage);
        }
        DestroyBullet(bulletLifetime);
    }
}

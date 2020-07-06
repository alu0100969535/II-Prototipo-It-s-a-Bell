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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyCollider"))
        {
            DestroyBullet(0);
            (other.gameObject).transform.parent.SendMessage("DamageTaken", damage);
        }

        DestroyBullet(bulletLifetime);
    }
}

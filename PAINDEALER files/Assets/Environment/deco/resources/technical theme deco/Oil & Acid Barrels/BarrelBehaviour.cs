using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private Health health;
    Animator animator;

    public int blastDamage = 30;
    public float radius = 5f;
    public AudioClip Xplosion;


    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
        animator = gameObject.GetComponent<Animator>();

    }


    void Explode()
    {
        Destroy(gameObject);
    }

    void ExplodeRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider NearbyObjects in colliders)
        {
            Health health = NearbyObjects.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(blastDamage);
            }
        }
    }

    void ExplodeSound()
    {
        AudioSource.PlayClipAtPoint(Xplosion, gameObject.transform.position);
    }
}

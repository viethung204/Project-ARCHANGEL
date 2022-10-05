using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectileScript : MonoBehaviour
{
    public float lifespan = 10f;
    public Animator animator;
    public GameObject Explosion;
    public int damage = 70;
    public int blastDamage = 30;
    public float radius = 3f;


    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        ExplodeRadius();

        if(collision.gameObject.tag == "Enemy")
        {
            //declare a Health varirable to get the Health script that this projectile collides with, it the sccript exist, call the TakeDamage method
            Health health = collision.transform.GetComponent<Health>();
            if ( health != null)
            {
                health.TakeDamage(damage);
            }
        }

      
    }

    void Explode()
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //For BLAST DAMAGE 
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
}

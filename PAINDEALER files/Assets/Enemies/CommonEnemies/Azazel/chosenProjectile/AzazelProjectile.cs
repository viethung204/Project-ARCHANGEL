using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelProjectile : MonoBehaviour
{

    public float lifespan = 10f;
    public GameObject Explosion;
    public float radius = 3f;


    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Explode();

        if (collision.gameObject.tag == "Player")
        {
            //declare a Health varirable to get the Health script that this projectile collides with, it the sccript exist, call the TakeDamage method
            playerHealth health = collision.transform.GetComponent<playerHealth>();
            if (health != null)
            {
                health.Health -= 5;
            }
        }


    }

    void Explode()
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}

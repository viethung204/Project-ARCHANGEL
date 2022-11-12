using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifespan;
    public GameObject Explosion;


    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "projectile" || collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        else
        {
            Explode();
        }

    }

    void Explode()
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

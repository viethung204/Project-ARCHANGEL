using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCProjectile : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody thisRigidbody;
    public float lifespan = 5f;
    public GameObject Explosion;
    public int blastDamage = 100;
    public float radius = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        thisRigidbody.AddForce(thisRigidbody.transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        ExplodeRadius();
    }

    void Explode()
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
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
}

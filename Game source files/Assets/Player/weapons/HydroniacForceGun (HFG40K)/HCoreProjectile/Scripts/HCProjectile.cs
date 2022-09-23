using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCProjectile : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody thisRigidbody;
    public float lifespan = 5f;
    //public GameObject Explosion;
    public GameObject AltExplosion;


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
    }

    void Explode()
    {
        //Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Instantiate(AltExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   


}

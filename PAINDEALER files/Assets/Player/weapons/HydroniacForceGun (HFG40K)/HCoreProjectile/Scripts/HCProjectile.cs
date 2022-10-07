using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCProjectile : MonoBehaviour
{

    public float lifespan = 5f;
    //public GameObject Explosion;
    public GameObject AltExplosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
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

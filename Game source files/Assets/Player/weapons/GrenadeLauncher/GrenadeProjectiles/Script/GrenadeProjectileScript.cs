using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectileScript : MonoBehaviour
{
    public float lifespan = 10f;
    public Animator animator;
    public GameObject Explosion;


    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

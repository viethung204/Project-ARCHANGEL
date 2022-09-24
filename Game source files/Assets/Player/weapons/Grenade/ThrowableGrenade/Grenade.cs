using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float lifespan = 10f;
    public GameObject Explosion;
    public int blastDamage = 30;
    public float radius = 3f;
    public AudioSource bounce;
    Animator GAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GAnimator = this.transform.GetComponent<Animator>();
        Destroy(gameObject, lifespan);
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Environment")
        {
            bounce.Play();
            GAnimator.SetBool("idle", true);
        }


    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(lifespan - 0.10f);
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
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

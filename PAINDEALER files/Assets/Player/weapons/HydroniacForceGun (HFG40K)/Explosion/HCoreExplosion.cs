using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCoreExplosion : MonoBehaviour
{
    public float lifespan = 0.949f;
    public new AudioSource audio;
    public int blastDamage = 100;
    public float radius = 50f;
    public float killDelay = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position);
        StartCoroutine(explosionDelay());
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    IEnumerator explosionDelay()
    {
        yield return new WaitForSeconds(killDelay);
        ExplodeRadius();
    }
}

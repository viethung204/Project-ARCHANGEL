using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float lifespan = 0.514f;
    public new AudioSource audio;
    public int blastDamage;
    public float radius = 50f;
    public float killDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position);
        StartCoroutine(explosionDelay());
        Destroy(gameObject, lifespan);
    }
    void ExplodeRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider NearbyObjects in colliders)
        {
            playerHealth health = NearbyObjects.transform.GetComponent<playerHealth>();
            if (health != null)
            {
                health.Health -= blastDamage;
            }
        }
    }

    IEnumerator explosionDelay()
    {
        yield return new WaitForSeconds(killDelay);
        ExplodeRadius();
    }
}

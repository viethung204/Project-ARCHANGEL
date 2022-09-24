using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltHCoreExplosion : MonoBehaviour
{
    public float lifespan = 0.545f;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position);
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

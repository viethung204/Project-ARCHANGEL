using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOHExplosion : MonoBehaviour
{
    public float lifespan = 0.514f;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position);
        Destroy(gameObject, lifespan);
    }

}

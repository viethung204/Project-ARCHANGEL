using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APExplosion : MonoBehaviour
{
    public float lifespan = 1.602f;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position);
        Destroy(gameObject, lifespan);
    }

}

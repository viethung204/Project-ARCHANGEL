using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifespan = 0.7f;
    public AudioSource audio;

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

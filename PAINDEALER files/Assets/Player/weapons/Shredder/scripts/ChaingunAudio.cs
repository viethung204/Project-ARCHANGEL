using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaingunAudio : MonoBehaviour
{
    public AudioSource shoot;
    public AudioSource revdown;
    public AudioSource revving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //play shoot sound
    void ShootAudio()
    {
        shoot.Play();
    }

    //play reload sound
    void RevdownAudio()
    {
        revdown.Play();
    }

    void RevvingAudio()
    {
        revving.Play();
    }
}

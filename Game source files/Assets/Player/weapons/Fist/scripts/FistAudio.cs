using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistAudio : MonoBehaviour
{
    public AudioSource punch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //play punch sound
    void PunchAudio()
    {
        punch.Play();
    }

}

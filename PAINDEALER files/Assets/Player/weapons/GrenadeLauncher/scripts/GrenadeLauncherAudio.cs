using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherAudio : MonoBehaviour
{
    public AudioSource shoot;
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

}

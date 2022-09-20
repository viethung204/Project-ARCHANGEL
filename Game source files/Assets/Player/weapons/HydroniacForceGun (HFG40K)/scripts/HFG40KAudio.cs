using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HFG40kAudio : MonoBehaviour
{
    public AudioSource shoot;
    public AudioSource idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootAudio()
    {
        shoot.Play();
    }

    void IdleAudio()
    {
        idle.Play();
    }
}

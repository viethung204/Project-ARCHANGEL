using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpShotgunAudio : MonoBehaviour
{
    public AudioSource shoot;
    public AudioSource reloadPump;
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
    void ReloadAudio()
    {
        reloadPump.Play();
    }
}

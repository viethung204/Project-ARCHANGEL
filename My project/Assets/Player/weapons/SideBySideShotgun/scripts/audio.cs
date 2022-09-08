using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource shoot;
    public AudioSource reload1;
    public AudioSource reload2;
    public AudioSource reload3;
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
    void Reload1Audio()
    {
        reload1.Play();
    }
    void Reload2Audio()
    {
        reload2.Play();
    }
    void Reload3Audio()
    {
        reload3.Play();
    }
}

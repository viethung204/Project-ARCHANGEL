using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCGZAudio : MonoBehaviour
{
    public AudioSource ShootAudio;
    public AudioSource ShootAudio1;
    public AudioSource ShootAudio2;
    public AudioSource ShootAudio3;
    public AudioSource DieAudio;
    public AudioSource HurtAudio;

    void PlayShootAudio()
    {
        ShootAudio.Play();
    }

    void PlayShootAudio1()
    {
        ShootAudio1.Play();
    }

    void PlayShootAudio2()
    {
        ShootAudio2.Play();
    }

    void PlayShootAudio3()
    {
        ShootAudio3.Play();
    }

    void PlayDieAudio()
    {
        DieAudio.Play();
    }

    void PlayHurtAudio()
    {
        HurtAudio.Play();
    }
}

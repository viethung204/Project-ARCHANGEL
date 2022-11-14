using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCGZAudio : MonoBehaviour
{
    public AudioClip ShootAudio;
    public AudioClip ShootAudio1;
    public AudioClip ShootAudio2;
    public AudioClip ShootAudio3;
    public AudioClip DieAudio;
    public AudioClip HurtAudio;

    void PlayShootAudio()
    {
        AudioSource.PlayClipAtPoint(ShootAudio, transform.position, 100f);
    }

    void PlayShootAudio1()
    {
        AudioSource.PlayClipAtPoint(ShootAudio1, transform.position, 100f);
    }

    void PlayShootAudio2()
    {
        AudioSource.PlayClipAtPoint(ShootAudio2, transform.position, 100f);
    }

    void PlayShootAudio3()
    {
        AudioSource.PlayClipAtPoint(ShootAudio3, transform.position, 100f);
    }

    void PlayDieAudio()
    {
        AudioSource.PlayClipAtPoint(DieAudio, transform.position, 20f);
    }

    void PlayHurtAudio()
    {
        AudioSource.PlayClipAtPoint(HurtAudio, transform.position, 100f);
    }
}

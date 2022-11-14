using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RottweilerAudio : MonoBehaviour
{
    public AudioClip BarkAudio;
    public AudioClip BarkAudio1;
    public AudioClip BarkAudio2;
    public AudioClip DieAudio;
    public AudioClip HurtAudio;

    private float randomBark;
    FieldOfView fovScript;


    private void Start()
    {
        fovScript = gameObject.GetComponent<FieldOfView>();
    }
    void PlayBarkAudio()
    {
        randomBark = Random.Range(0f, 10f);
        if(randomBark <= 3 && fovScript.canSeePlayer == true || fovScript.angle == 360f)
        {
            AudioSource.PlayClipAtPoint(BarkAudio, transform.position);
        }
        else
        {
            return;
        }
    }

    void PlayBarkAudio1()
    {
        AudioSource.PlayClipAtPoint(BarkAudio1, transform.position);
    }

    void PlayBarkAudio2()
    {
        AudioSource.PlayClipAtPoint(BarkAudio2, transform.position);
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

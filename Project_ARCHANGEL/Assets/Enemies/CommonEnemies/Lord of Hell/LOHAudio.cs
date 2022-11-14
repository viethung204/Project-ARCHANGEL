using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOHAudio : MonoBehaviour
{
    public AudioClip ShootAudio;
    public AudioClip GrowlAudio;
    public AudioClip DieAudio;
    public AudioClip HurtAudio;

    private float randomGrowl;
    FieldOfView fovScript;

    private void Start()
    {
        fovScript = gameObject.GetComponent<FieldOfView>();
    }

    void PlayShootAudio()
    {
        AudioSource.PlayClipAtPoint(ShootAudio, transform.position, 100f);
    }

    void PlayGrowlAudio()
    {
        randomGrowl = Random.Range(0f, 10f);
        if (randomGrowl <= 3 && fovScript.canSeePlayer == true || fovScript.angle == 360f)
        {
            AudioSource.PlayClipAtPoint(GrowlAudio, transform.position, 100f);
        }
        else
        {
            return;
        }
        
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

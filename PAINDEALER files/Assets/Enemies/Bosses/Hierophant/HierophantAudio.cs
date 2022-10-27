using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierophantAudio : MonoBehaviour
{
    public AudioClip ShootAudio1;
    public AudioClip ShootAudio2;
    public AudioClip RoamAudio;
    public AudioClip DieAudio;
    public AudioClip HurtAudio;

    private float randomRoam;
    FieldOfView fovScript;

    private void Start()
    {
        fovScript = gameObject.GetComponent<FieldOfView>();
    }

    void PlayShootAudio1()
    {
        AudioSource.PlayClipAtPoint(ShootAudio1, transform.position, 100f);
    }

    void PlayShootAudio2()
    {
        AudioSource.PlayClipAtPoint(ShootAudio2, transform.position, 100f);
    }

    void PlayRoamAudio()
    {
        randomRoam = Random.Range(0f, 10f);
        if (randomRoam <= 3 && (fovScript.canSeePlayer == true || fovScript.angle == 360f))
        {
            AudioSource.PlayClipAtPoint(RoamAudio, transform.position, 100f);
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

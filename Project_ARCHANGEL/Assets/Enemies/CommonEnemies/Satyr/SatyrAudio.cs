using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatyrAudio : MonoBehaviour
{
    public AudioClip MeleeAudio;
    public AudioClip WalkAudio;
    public AudioClip WalkAudio1;
    public AudioClip WalkAudio2;
    public AudioClip DieAudio;
    public AudioClip HurtAudio;

    private float randomGrowl;
    FieldOfView fovScript;

    private void Start()
    {
        fovScript = gameObject.GetComponent<FieldOfView>();
    }

    void PlayMeleeAudio()
    {
        AudioSource.PlayClipAtPoint(MeleeAudio, transform.position, 100f);
    }

    void PlayWalkAudio()
    {
        randomGrowl = Random.Range(0f, 10f);
        if (randomGrowl <= 3 && randomGrowl > 0 && fovScript.canSeePlayer == true || fovScript.angle == 360f)
        {
            AudioSource.PlayClipAtPoint(WalkAudio, transform.position, 100f);
        }
        if (randomGrowl <= 6 && randomGrowl > 3 && fovScript.canSeePlayer == true || fovScript.angle == 360f)
        {
            AudioSource.PlayClipAtPoint(WalkAudio1, transform.position, 100f);
        }
        if (randomGrowl <= 9 && randomGrowl > 6 && fovScript.canSeePlayer == true || fovScript.angle == 360f)
        {
            AudioSource.PlayClipAtPoint(WalkAudio2, transform.position, 100f);
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

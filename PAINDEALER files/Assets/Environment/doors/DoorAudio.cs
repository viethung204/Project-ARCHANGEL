using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    public AudioClip clip;

    void SFX()
    {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }
}

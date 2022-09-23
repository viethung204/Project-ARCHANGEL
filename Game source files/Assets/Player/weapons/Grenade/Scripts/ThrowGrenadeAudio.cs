using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeAudio : MonoBehaviour
{

    public AudioSource pullingPin;
    public AudioSource throwSound;

    void pullingPinAudo()
    {
        pullingPin.Play();
    }

    void ThrowAudio()
    {
        throwSound.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LightInteractable : MonoBehaviour
{
    public UnityEvent onInteract;
    new Light light;
    SpriteRenderer spriteRenderer;
    public Sprite On;
    public Sprite Off;
    public AudioClip OnAudio;
    public AudioClip OffAudio;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnNOff()
    {
        //cant be if if because you will turn it off than turn it back on immediately when interact, since it executes by order of writing
        //why am i writing this, this is literally the basic lmao

        if(light.enabled == true)
        {
            light.enabled = false;
            spriteRenderer.sprite = Off;
            AudioSource.PlayClipAtPoint(OffAudio, gameObject.transform.position);
            
        }
        else if(light.enabled == false)
        {
            light.enabled = true;
            spriteRenderer.sprite = On;
            AudioSource.PlayClipAtPoint(OnAudio, gameObject.transform.position);
        }
    }
}

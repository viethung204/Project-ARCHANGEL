using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LightInteractable : MonoBehaviour
{
    public UnityEvent onInteract;
    new GameObject light;
    SpriteRenderer spriteRenderer;
    public Sprite On;
    public Sprite Off;
    public AudioClip OnAudio;
    public AudioClip OffAudio;

    private void Start()
    {
        light = gameObject.transform.GetChild(0).gameObject;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnNOff()
    {
        //cant be if if because you will turn it off than turn it back on immediately when interact, since it executes by order of writing
        //why am i writing this, this is literally the basic lmao

        if(light.activeSelf == true)
        {
            light.SetActive(false);
            spriteRenderer.sprite = Off;
            AudioSource.PlayClipAtPoint(OffAudio, gameObject.transform.position);
            
        }
        else if(light.activeSelf == false)
        {
            light.SetActive(true);
            spriteRenderer.sprite = On;
            AudioSource.PlayClipAtPoint(OnAudio, gameObject.transform.position);
        }
    }
}

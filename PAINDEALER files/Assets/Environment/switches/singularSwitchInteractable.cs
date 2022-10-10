using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class singularSwitchInteractable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite On;
    public Sprite Off;
    public AudioClip SwitchAudio;
    SpriteRenderer spriteRenderer;
    public Animator doorAnimator;
    int animLayer = 0;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Switching()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            spriteRenderer.sprite = On;
            AudioSource.PlayClipAtPoint(SwitchAudio, gameObject.transform.position);
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}

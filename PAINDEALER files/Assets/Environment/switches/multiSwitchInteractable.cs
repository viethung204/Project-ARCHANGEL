using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class multiSwitchInteractable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite On;
    public Sprite Off;
    public AudioClip SwitchAudio;
    SpriteRenderer spriteRenderer;
    public Animator doorAnimator;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Switching()
    {
           if(gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            spriteRenderer.sprite = On;
            gameObject.layer = LayerMask.NameToLayer("Default");
            StartCoroutine(ReSwitch());
            AudioSource.PlayClipAtPoint(SwitchAudio, gameObject.transform.position);
            
        }
           else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    IEnumerator ReSwitch()
    {
        yield return new WaitForSeconds(4f);
        gameObject.layer = LayerMask.NameToLayer("interactable");
        spriteRenderer.sprite = Off;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManualDoorBehaviour : MonoBehaviour
{
    public UnityEvent onInteract;
    public Animator animator;
    int animLayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            animator.SetTrigger("on");
            //AudioSource.PlayClipAtPoint(SwitchAudio, gameObject.transform.position);
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    void Update()
    {
        if (isPlaying(animator, "on"))
        {
            StartCoroutine(AnimWait());
        }
        if (isPlaying(animator, "idle"))
        {
            animator.ResetTrigger("off");
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

    IEnumerator AnimWait()
    {
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("off");
        gameObject.layer = LayerMask.NameToLayer("interactable");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorBehaviour : MonoBehaviour
{
    int animLayer = 0;
    public Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying(animator, "on"))
        {
            StartCoroutine(AnimWait());
        }
        if(isPlaying(animator, "idle"))
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
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("off");
    }
}

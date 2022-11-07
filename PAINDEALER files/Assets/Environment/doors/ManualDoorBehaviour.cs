using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManualDoorBehaviour : MonoBehaviour
{
    public UnityEvent onInteract;
    public Animator animator;
    int animLayer = 0;

    interactor keyCheck;
    private Text WeaponsNoti;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        keyCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<interactor>();
        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();
    }

    public void OpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            animator.SetTrigger("on");
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    public void REDOpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.redKey == true)
        {
            animator.SetTrigger("on");
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.redKey == false)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You need the RED key";
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    public void BLUEOpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.blueKey == true)
        {
            animator.SetTrigger("on");
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.blueKey == false)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You need the BLUE key";
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    public void GREENOpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.greenKey == true)
        {
            animator.SetTrigger("on");
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.greenKey == false)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You need the GREEN key";
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            return;
        }

    }

    public void YELLOWOpenDoor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.yellowKey == true)
        {
            animator.SetTrigger("on");
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else if (gameObject.layer == LayerMask.NameToLayer("interactable") && keyCheck.yellowKey == false)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You need the YELLOW key";
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

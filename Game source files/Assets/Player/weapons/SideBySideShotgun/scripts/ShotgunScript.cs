using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShotgunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCam;
    public float CurrentAmmo = 2f;
    public float InvAmmo = 10f;
    const float MaxAmmo = 2f;
    public Animator animator;
    public Text currentAmmoText;
    public Text invAmmoText;
    int animLayer = 0;
    public AudioSource EmptyClick;
    

    void Update()
    {           
        //display ammo in UI
        currentAmmoText.text = CurrentAmmo.ToString();
        invAmmoText.text = InvAmmo.ToString("00#");
       
        if(Input.GetButtonDown("Fire1"))
        {
            ShootConditions();
        }
        
        //play headbobbing animation
        animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //check for conditions before shoot to determine how to reload
    void ShootConditions()
    {
        if (CurrentAmmo > 0 && InvAmmo != 0 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("mouse1");
            CurrentAmmo -=2;
            StartCoroutine(ReloadUI());
        }
        else if (CurrentAmmo == 0 && InvAmmo > 0 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            StartCoroutine(ReloadUI());
            animator.SetTrigger("rkey");
        }
        else if (CurrentAmmo == 2 && InvAmmo == 0 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("ShootOnly");
            CurrentAmmo -=2 ;
        }
        else if (CurrentAmmo ==0 && InvAmmo == 0 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThen Reload"))
        {
            //play *click* sound
            EmptyClick.Play();    
        }
    }

    //it's in the name
     void ShootMechanics()
    {
        RaycastHit HitInfo;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out HitInfo, range))
        {
            Health health = HitInfo.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    //put here so the UI get update after reload animation done playing
    IEnumerator ReloadUI()
    {
        
        yield return new WaitForSeconds(1.27f);
        CurrentAmmo += 2;
        InvAmmo -= 2;    
    }

    //check if animtion is playing
    public bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GunScript : MonoBehaviour
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
            Shoot();
        }

       if (Input.GetKeyDown(KeyCode.R) && !isPlaying(animator, "reload"))
        {
            Reload();
        }
        
        //play headbobbing animation
        animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //it is in the name (but check if the CurrentAmmo is 0 after shoot, if true, reload
    //note: if 2 trigger set at once, you can set the priority in the Animator
    void Shoot()
    {
        if (CurrentAmmo > 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload"))
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
            animator.SetTrigger("mouse1");
            CurrentAmmo-=2;
            if (CurrentAmmo == 0 && InvAmmo > 0 && !isPlaying(animator, "reload"))
            {
                Reload();

            }
        }
        else if (CurrentAmmo == 0 && InvAmmo == 0)
        {
            //play *click* sound
            EmptyClick.Play();
            
        }
        else if (CurrentAmmo == 0 && InvAmmo > 0 && !isPlaying(animator, "reload"))
        {
            Reload();

        }
        

    }

    //Reload
    void Reload()
    {
        if (InvAmmo >= MaxAmmo && CurrentAmmo != MaxAmmo)
        {
            animator.SetTrigger("rkey");
            StartCoroutine(ReloadUI());
        }
        else if (InvAmmo<MaxAmmo && CurrentAmmo != MaxAmmo && InvAmmo != 0)
        {
            animator.SetTrigger("rkey");
            StartCoroutine(ReloadUI());
        }
        else if (InvAmmo == 0)
        {
            return;
        }
        else if (CurrentAmmo == MaxAmmo)
        {
            return;
        }
        else if (CurrentAmmo==0 && InvAmmo == 0)
        {
            return;
        }   
    }

    //put here so the UI get update after reload animation done playing
    IEnumerator ReloadUI()
    {
        yield return new WaitForSeconds(1.27f);
        if (InvAmmo >= MaxAmmo && CurrentAmmo != MaxAmmo)
        {
            //Update InvAmmo first be4 update CurrentAmmo (if you let CA update first it will be InvAmmo = InvAmmo - n + n because now CA and MA are the same)
            InvAmmo = InvAmmo - MaxAmmo + CurrentAmmo;
            CurrentAmmo = MaxAmmo;

        }
        else if (InvAmmo < MaxAmmo && CurrentAmmo != MaxAmmo && InvAmmo != 0)
        {
            CurrentAmmo = CurrentAmmo + InvAmmo;
            InvAmmo = 0;
        }
    }

    //check if animtion is playing
    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}


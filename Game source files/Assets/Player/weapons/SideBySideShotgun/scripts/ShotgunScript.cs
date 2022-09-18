using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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
    public Text weaponName;
    public Text ammoDivider;
    public GameObject UIWeaponIcon;
    public Sprite weaponIcon;
    public Image weaponIconRect;
    int animLayer = 0;
    public AudioSource EmptyClick;
    public Text ammoType;
    public Image UICrosshair;
    public Sprite crosshair;
    public SC_FPSController speed;

    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = "12g";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(true);
        ammoDivider.gameObject.SetActive(true);
        currentAmmoText.text = CurrentAmmo.ToString();
        invAmmoText.text = InvAmmo.ToString("00#");
        weaponName.text = "A1 Shotgun";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(100f, 100f);

        speed.walkingSpeed = 11.5f;
        speed.runningSpeed = 11.5f;


        if (Input.GetButtonDown("Fire1"))
        {
            ShootConditions();
        }
        
        //play headbobbing animation
        animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //check for conditions before shoot to determine how to reload
    void ShootConditions()
    {
        if (CurrentAmmo > 0 && InvAmmo >1  && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("mouse1");
            CurrentAmmo -=2;
            StartCoroutine(ReloadUI());
        }
        else if (CurrentAmmo == 0 && InvAmmo > 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            StartCoroutine(ReloadUI());
            animator.SetTrigger("rkey");
        }
        else if (CurrentAmmo == 2 && InvAmmo <= 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("ShootOnly");
            CurrentAmmo -=2 ;
        }
        else if (CurrentAmmo ==0 && InvAmmo <= 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThen Reload"))
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


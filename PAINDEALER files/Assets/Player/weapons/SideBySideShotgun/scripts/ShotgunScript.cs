using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class ShotgunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCam;
    public float CurrentAmmo = 2f;
    const float MaxAmmo = 2f;
    public AmmoManager ammoManager;
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
    

    public float maxSpread;
    public int pellets;

    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = "12g";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(true);
        ammoDivider.gameObject.SetActive(true);
        currentAmmoText.text = CurrentAmmo.ToString();
        invAmmoText.text = AmmoManager.ShotgunInvAmmo.ToString("00#");
        weaponName.text = "A1 Shotgun";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(90f, 90f);


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
        if (CurrentAmmo > 0 && AmmoManager.ShotgunInvAmmo > 1  && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("mouse1");
            CurrentAmmo -=2;
            StartCoroutine(ReloadUI());
        }
        else if (CurrentAmmo == 0 && AmmoManager.ShotgunInvAmmo > 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            StartCoroutine(ReloadUI());
            animator.SetTrigger("rkey");
        }
        else if (CurrentAmmo == 2 && AmmoManager.ShotgunInvAmmo <= 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThenReload"))
        {
            ShootMechanics();
            animator.SetTrigger("ShootOnly");
            CurrentAmmo -=2 ;
        }
        else if (CurrentAmmo ==0 && AmmoManager.ShotgunInvAmmo <= 1 && !isPlaying(animator, "Shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "ShootThen Reload"))
        {
            //play *click* sound
            EmptyClick.Play();    
        }
    }

    //it's in the name
     void ShootMechanics()
    {
        RaycastHit HitInfo;
        ShootSound();
        for (int i = 0; i < pellets; i++)
        {
            var direction = PlayerCam.transform.forward + new Vector3(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread), 0f);
            if (Physics.Raycast(PlayerCam.transform.position, direction, out HitInfo, range))
            {
                if(HitInfo.transform.tag == "Enemy")
                {
                    Health health = HitInfo.transform.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }
                }

            }
        }
    }

    //put here so the UI get update after reload animation done playing
    IEnumerator ReloadUI()
    {
        
        yield return new WaitForSeconds(1.27f);
        CurrentAmmo += 2;
        AmmoManager.ShotgunInvAmmo -= 2;    
    }

    public void ShootSound()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);
        foreach (Collider NearbyObjects in colliders)
        {
            hearing hearScript = NearbyObjects.transform.GetComponent<hearing>();
            if (hearScript != null && hearScript.enabled == true)
            {
                hearScript.shotfired = true;
            }
        }
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


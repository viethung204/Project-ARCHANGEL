using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class RevolverScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCam;
    public int RevolverCurrentAmmo = 6;
    const int RevolverMaxAmmo = 6;
    public Animator animator;
    public Text currentAmmoText;
    public Text invAmmoText;
    public Text weaponName;
    public Text ammoDivider;
    public GameObject UIWeaponIcon;
    public Sprite weaponIcon;
    public Image weaponIconRect;
    int animLayer = 0;
    public Text ammoType;
    public AudioSource EmptyClick;
    public Image UICrosshair;
    public Sprite crosshair;


    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = ".308";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(true);
        ammoDivider.gameObject.SetActive(true);
        weaponName.text = "Revolver";
        currentAmmoText.text = RevolverCurrentAmmo.ToString();
        invAmmoText.text = AmmoManager.RevolverInvAmmo.ToString("00#");
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(100f, 100f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(100f, 100f);

        
        if (Input.GetButtonDown("Fire1"))
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
        if (RevolverCurrentAmmo > 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload"))
        {
            ShootSound();
            RaycastHit HitInfo;
            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out HitInfo, range))
            {
                Health health = HitInfo.transform.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }


            }
            animator.SetTrigger("shoot");
            RevolverCurrentAmmo--;
            if (RevolverCurrentAmmo == 0 && AmmoManager.RevolverInvAmmo > 0 && !isPlaying(animator, "reload"))
            {
                Reload();
            }
            
        }
        else if (RevolverCurrentAmmo == 0 && AmmoManager.RevolverInvAmmo == 0)
        {
            //play *click* sound
            EmptyClick.Play();

        }
        else if (RevolverCurrentAmmo == 0 && AmmoManager.RevolverInvAmmo > 0 && !isPlaying(animator, "reload"))
        {
            Reload();

        }


    }

    //Reload
    void Reload()
    {
        if (AmmoManager.RevolverInvAmmo >= RevolverMaxAmmo && RevolverCurrentAmmo != RevolverMaxAmmo)
        {
            animator.SetTrigger("rkey");
            StartCoroutine(ReloadUI());
        }
        else if (AmmoManager.RevolverInvAmmo < RevolverMaxAmmo && RevolverCurrentAmmo != RevolverMaxAmmo && AmmoManager.RevolverInvAmmo != 0)
        {
            animator.SetTrigger("rkey");
            StartCoroutine(ReloadUI());
        }
        else if (AmmoManager.RevolverInvAmmo == 0)
        {
            return;
        }
        else if (RevolverCurrentAmmo == RevolverMaxAmmo)
        {
            return;
        }
        else if (RevolverCurrentAmmo == 0 && AmmoManager.RevolverInvAmmo == 0)
        {
            return;
        }
    }

    //put here so the UI get update after reload animation done playing
    IEnumerator ReloadUI()
    {
        yield return new WaitForSeconds(1.27f);
        if (AmmoManager.RevolverInvAmmo >= RevolverMaxAmmo && RevolverCurrentAmmo != RevolverMaxAmmo)
        {
            //Update InvAmmo first be4 update CurrentAmmo (if you let CA update first it will be InvAmmo = InvAmmo - n + n because now CA and MA are the same)
            AmmoManager.RevolverInvAmmo = AmmoManager.RevolverInvAmmo - RevolverMaxAmmo + RevolverCurrentAmmo;
            RevolverCurrentAmmo = RevolverMaxAmmo;

        }
        else if (AmmoManager.RevolverInvAmmo < RevolverMaxAmmo && RevolverCurrentAmmo != RevolverMaxAmmo && AmmoManager.RevolverInvAmmo != 0)
        {
            RevolverCurrentAmmo = RevolverCurrentAmmo + AmmoManager.RevolverInvAmmo;
            AmmoManager.RevolverInvAmmo = 0;
        }
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
    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}

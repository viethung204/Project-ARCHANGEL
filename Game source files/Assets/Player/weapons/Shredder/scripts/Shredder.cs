using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
public class Shredder : MonoBehaviour
{
    public float damage = 5f;
    public float range = 100f;
    public Camera PlayerCam;
    public int ShredderInvAmmo = 100;
    public Text ammoDivider;
    public Animator animator;
    public Text currentAmmoText;
    public Text invAmmoText;
    public Text weaponName;
    public GameObject UIWeaponIcon;
    public Sprite weaponIcon;
    public Image weaponIconRect;
    int animLayer = 0;
    public Text ammoType;
    public int RateOFire = 50;
    public AudioSource EmptyClick;
    public Image UICrosshair;
    public Sprite crosshair;
    public AudioSource revvingSound;
    public SC_FPSController speed;

    private float NextTimeToShot = 0f;

    public Recoil RecoilScript;

    public void Start()
    {

    }

    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = ".50 bmg";
        weaponName.text = "Shredder";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(false);
        ammoDivider.gameObject.SetActive(false);
        invAmmoText.text = ShredderInvAmmo.ToString("00#");
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(100f, 100f);


        if(Input.GetButton("Fire1") && ShredderInvAmmo > 0)
        {
            speed.walkingSpeed = 5f;
            speed.runningSpeed = 5f;
        }
        else
        {
            speed.walkingSpeed = 7f;
            speed.runningSpeed = 7f;
        }

        if (Input.GetButton("Fire1") &&  Time.time > NextTimeToShot)
        {
            NextTimeToShot = Time.time + 1f / RateOFire;
            Shoot();  
        }
        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("shoot", false);
            revvingSound.Stop();
            animator.SetTrigger("revout");
        }

        //play headbobbing animation
        animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //it is in the name (but check if the CurrentAmmo is 0 after shoot, if true, reload
    //note: if 2 trigger set at once, you can set the priority in the Animator
    void Shoot()
    {
        if (ShredderInvAmmo > 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "revving down"))
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
            animator.SetBool("shoot", true);
            RecoilScript.RecoilFire();
        }
        if (ShredderInvAmmo <= 0)
        {
            revvingSound.Stop();
            animator.SetBool("shoot", false);
            animator.SetTrigger("revout");
        }
        else if (ShredderInvAmmo == 0)
        {
            //play *click* sound
            EmptyClick.Play();
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

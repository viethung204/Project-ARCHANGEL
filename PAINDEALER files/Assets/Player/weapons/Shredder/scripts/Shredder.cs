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
    public int ShredderInvAmmo;
    public GameObject RecoilSys;
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

    private float NextTimeToShot = 0f;

    public Recoil RecoilScript;

    private void Start()
    {
        //find ammo manager
        AmmoManager ammoManager = (GameObject.Find("Weapons Holder")).GetComponent<AmmoManager>();
        ShredderInvAmmo = ammoManager.ShredderInvAmmo;
    }

    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = ".50bmg";
        weaponName.text = "Shredder";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.text = ShredderInvAmmo.ToString("00#");
        invAmmoText.text = "XXX";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(100f, 100f);

        RecoilScript.RecoilX = -5f;
        RecoilScript.RecoilY = 5f;
        RecoilScript.RecoilZ = .35f;
        RecoilScript.snappiness = 6f;
        RecoilScript.returnSpeed = 2f;


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
            ShootSound();
            RaycastHit HitInfo;
            if (Physics.Raycast(RecoilSys.transform.position, RecoilSys.transform.forward, out HitInfo, range))
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

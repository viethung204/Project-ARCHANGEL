using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;
public class PumpShotgun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 50f;
    public Camera PlayerCam;
    public float CurrentAmmo = 1f;
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
        weaponName.text = "Shotgun";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.text = CurrentAmmo.ToString();
        invAmmoText.text = AmmoManager.ShotgunInvAmmo.ToString("00#");
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

    //it is in the name (but check if the CurrentAmmo is 0 after shoot, if true, reload
    //note: if 2 trigger set at once, you can set the priority in the Animator
    void ShootConditions()
    {
        if (CurrentAmmo > 0 && AmmoManager.ShotgunInvAmmo > 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "shootonly") && !isPlaying(animator, "reloadOnly"))
        {
            Shoot();
            animator.SetTrigger("shoot");
            CurrentAmmo --;
            StartCoroutine(ReloadUI());
        }
        else if (CurrentAmmo == 0 && AmmoManager.ShotgunInvAmmo > 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "shootonly") && !isPlaying(animator, "reloadOnly"))
        {
            StartCoroutine(ReloadUI());
            animator.SetTrigger("reloadOnly");
        }
        else if (CurrentAmmo == 1 && AmmoManager.ShotgunInvAmmo <= 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "shootonly") && !isPlaying(animator, "reloadOnly"))
        {
            Shoot();
            animator.SetTrigger("oneleft");
            CurrentAmmo --;
        }
        else if (CurrentAmmo == 0 && AmmoManager.ShotgunInvAmmo <= 0 && !isPlaying(animator, "shoot") && !isPlaying(animator, "reload") && !isPlaying(animator, "shootonly") && !isPlaying(animator, "reloadOnly"))
        {
            //play *click* sound
            EmptyClick.Play();
        }
    }


    void Shoot()
    {
        ShootSound();
        RaycastHit HitInfo;
        for (int i = 0; i < pellets; i++)
        {
            var direction = PlayerCam.transform.forward + new Vector3(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread), 0f);
            if (Physics.Raycast(PlayerCam.transform.position, direction, out HitInfo, range))
            {
                if (HitInfo.transform.tag == "Enemy")
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

    IEnumerator ReloadUI()
    {
        yield return new WaitForSeconds(0.6f);
        CurrentAmmo += 1;
        AmmoManager.ShotgunInvAmmo -= 1;
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

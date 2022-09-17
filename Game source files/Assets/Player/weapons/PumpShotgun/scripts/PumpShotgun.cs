using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
public class PumpShotgun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 50f;
    public Camera PlayerCam;
    public float CurrentAmmo;
    public Animator animator;
    public Text currentAmmoText;
    public Text invAmmoText;
    public Text weaponName;
    public Text ammoDivider;
    public GameObject UIWeaponIcon;
    public Sprite weaponIcon;
    public Image weaponIconRect;
    int animLayer = 0;
    public ShotgunScript shotgunscript4shells;
    public AudioSource EmptyClick;

    void Update()
    {

        //display ammo and weapon name and icon in UI
        weaponName.text = "Shotgun";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(false);
        ammoDivider.gameObject.SetActive(false);
        invAmmoText.text = shotgunscript4shells.InvAmmo.ToString("00#");
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


        //play headbobbing animation
        animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //it is in the name (but check if the CurrentAmmo is 0 after shoot, if true, reload
    //note: if 2 trigger set at once, you can set the priority in the Animator
    void Shoot()
    {
        if (shotgunscript4shells.InvAmmo > 1 && !isPlaying(animator, "shoot") && !isPlaying(animator, "shootonly"))
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
            animator.SetTrigger("shoot");
            shotgunscript4shells.InvAmmo--;
        }
        else if (shotgunscript4shells.InvAmmo == 1 && !isPlaying(animator, "shoot") && !isPlaying(animator, "shootonly"))
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
            animator.SetTrigger("oneleft");
            shotgunscript4shells.InvAmmo--;
        }

        else if (shotgunscript4shells.InvAmmo == 0)
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

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GrenadeLauncher : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCam;
    public float GLInvAmmo = 10f;
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
    public SC_FPSController speed;

    public GameObject grenadeProjectile;
    public GameObject SpawnLocation;

    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = "40mm";
        weaponName.text = "MGL";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(false);
        ammoDivider.gameObject.SetActive(false);
        invAmmoText.text = GLInvAmmo.ToString("00#");
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(128f, 128f);

        speed.walkingSpeed = 11.5f;
        speed.runningSpeed = 11.5f;

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
        if (GLInvAmmo > 0 && !isPlaying(animator, "shoot"))
        {
            Instantiate(grenadeProjectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
            animator.SetTrigger("shoot");
            GLInvAmmo -= 1;
        }
        else if (GLInvAmmo == 0)
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

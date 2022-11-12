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

    public GameObject grenadeProjectile;
    public GameObject SpawnLocation;

    public float throwForce;
    public float throwUpwardForce;

    public Recoil RecoilScript;


    void Update()
    {

        
        //display ammo and weapon name and icon in UI
        ammoType.text = "40mm";
        weaponName.text = "MGL";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.text = AmmoManager.GLInvAmmo.ToString("00#");
        invAmmoText.text = "XXX";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(90f, 90f);

        RecoilScript.RecoilX = -1f;
        RecoilScript.RecoilY = 1f;
        RecoilScript.RecoilZ = .35f;
        RecoilScript.snappiness = 9f;
        RecoilScript.returnSpeed = 4f;

        if (Input.GetButton("Fire1"))
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

        if (AmmoManager.GLInvAmmo > 0 && !isPlaying(animator, "shoot"))
        {
            //Create a new gameObject out of the newly spawn projectile
            GameObject grenade =  Instantiate(grenadeProjectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

            //get its rigidbody
            Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

            //calculate force 
            Vector3 force = SpawnLocation.transform.forward * throwForce + transform.up * throwUpwardForce;

            //apply the force
            projectileRb.AddForce(force, ForceMode.Impulse);

            animator.SetTrigger("shoot");
            AmmoManager.GLInvAmmo -= 1;
            RecoilScript.RecoilFire();
        }
        else if (AmmoManager.GLInvAmmo == 0)
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

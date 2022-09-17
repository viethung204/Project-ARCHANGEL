using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Image = UnityEngine.UI.Image;

public class Fist : MonoBehaviour
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
    int animLayer = 0;
    public AudioSource EmptyClick;
    int chosenNumber;
    public Text ammoType;
    public Image UICrosshair;
    public Sprite crosshair;



    void Update()
    {
        //display ammo and wepaon name in UI
        ammoType.text = "X";
        UIWeaponIcon.gameObject.SetActive(false);
        currentAmmoText.gameObject.SetActive(true);
        ammoDivider.gameObject.SetActive(true);
        currentAmmoText.text = "X";
        invAmmoText.text = "XXX";
        weaponName.text = "";
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(128f, 128f);

        if (Input.GetButtonDown("Fire1") && !isPlaying(animator, "punching") & !isPlaying(animator,"punching2"))
        {
            Shoot();
        }

        
        //play headbobbing animation
        //animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    //it is in the name (but check if the CurrentAmmo is 0 after shoot, if true, reload
    //note: if 2 trigger set at once, you can set the priority in the Animator
    void Shoot()
    {
        chosenNumber = Random.Range(1, 10);

        RaycastHit HitInfo;
            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out HitInfo, range))
            {
                Health health = HitInfo.transform.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        if(chosenNumber < 5)
        {
            animator.SetTrigger("punch");
        }
        else if (chosenNumber > 5)
        {
            animator.SetTrigger("punch2");
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


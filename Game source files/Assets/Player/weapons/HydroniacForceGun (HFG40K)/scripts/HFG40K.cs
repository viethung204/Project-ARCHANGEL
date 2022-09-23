using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HFG40K : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCam;
    public int CoreInvAmmo = 10;
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

    public GameObject ECoreProjectile;
    public GameObject SpawnLocation;

    public Recoil RecoilScript;

    private void Start()
    {
        animator.SetInteger("ammo", CoreInvAmmo);
    }
    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = "h-core";
        weaponName.text = "HFG40K";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.text = CoreInvAmmo.ToString("00#");
        invAmmoText.text = "XXX";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(150f, 150f);

        speed.walkingSpeed = 7f;
        speed.runningSpeed = 7f;

        RecoilScript.RecoilX = -5f;
        RecoilScript.RecoilY = 0;
        RecoilScript.RecoilZ = .35f;
        RecoilScript.snappiness = 9f;
        RecoilScript.returnSpeed = 4f;

        if (isPlaying(animator, "shoot"))
        {
            speed.walkingSpeed = 5f;
            speed.runningSpeed = 5f;
        }

        animator.SetInteger("ammo", CoreInvAmmo);

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
        if (CoreInvAmmo > 0 && !isPlaying(animator, "shoot"))
        {
            StartCoroutine(WaitAnim());
            //StartCoroutine(Recoil());
            animator.SetTrigger("shoot");

        }
        else if (CoreInvAmmo == 0)
        {
            //play *click* sound
            EmptyClick.Play();

        }

    }

    //animation first, projectile comes later
    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(0.9f);
        Instantiate(ECoreProjectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        CoreInvAmmo -= 1;
        RecoilScript.RecoilFire();
    }

    //Recoil
   /* IEnumerator Recoil()
    {
        yield return new WaitForSeconds(0.9f);
        RecoilScript.RecoilFire();
    } */

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

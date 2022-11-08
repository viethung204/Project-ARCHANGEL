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

    public GameObject ECoreProjectile;
    public GameObject SpawnLocation;

    public float throwForce;

    public Recoil RecoilScript;

    private void Start()
    {
        //make it so play idle anim
        animator.SetInteger("ammo", AmmoManager.CoreInvAmmo);
    }
    void Update()
    {
        //display ammo and weapon name and icon in UI
        ammoType.text = "h-core";
        weaponName.text = "HFG40K";
        UIWeaponIcon.gameObject.SetActive(true);
        currentAmmoText.text = AmmoManager.CoreInvAmmo.ToString("00#");
        invAmmoText.text = "XXX";
        UIWeaponIcon.GetComponent<Image>().sprite = weaponIcon;
        weaponIconRect.rectTransform.sizeDelta = new Vector2(150f, 150f);
        UICrosshair.GetComponent<Image>().sprite = crosshair;
        UICrosshair.rectTransform.sizeDelta = new Vector2(100f, 100f);

        RecoilScript.RecoilX = -5f;
        RecoilScript.RecoilY = 0;
        RecoilScript.RecoilZ = .35f;
        RecoilScript.snappiness = 9f;
        RecoilScript.returnSpeed = 4f;

        animator.SetInteger("ammo", AmmoManager.CoreInvAmmo);

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
        if (AmmoManager.CoreInvAmmo > 0 && !isPlaying(animator, "shoot"))
        {
            ShootSound();
            StartCoroutine(WaitAnim());
            //StartCoroutine(Recoil());
            animator.SetTrigger("shoot");

        }
        else if (AmmoManager.CoreInvAmmo == 0)
        {
            //play *click* sound
            EmptyClick.Play();

        }

    }

    //animation first, projectile comes later
    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(0.6f);
        //Create a new gameObject out of the newly spawn projectile
        GameObject grenade = Instantiate(ECoreProjectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

        //get its rigidbody
        Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

        //calculate force 
        Vector3 force = SpawnLocation.transform.forward * throwForce;

        //apply the force
        projectileRb.AddForce(force, ForceMode.Impulse);
        AmmoManager.CoreInvAmmo -= 1;
        RecoilScript.RecoilFire();
    }

    //Recoil
    /* IEnumerator Recoil()
     {
         yield return new WaitForSeconds(0.9f);
         RecoilScript.RecoilFire();
     } */

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

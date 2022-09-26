using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpShotgunPickup : MonoBehaviour
{
    private GameObject Shotgun;
    private SpriteRenderer ShotgunSpriteRenderer;
    private PumpShotgun shotgunScript;

    private Transform WeaponsHolder;

    private WeaponsNotiController WeaponPickupNoti;
    private Text WeaponsNoti;

    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;

    // Start is called before the first frame update
    void Start()
    {
        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();

        WeaponPickupNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();

        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

        Shotgun = GameObject.Find("PumpShotgun");
        ShotgunSpriteRenderer = (GameObject.Find("PumpShotgun")).gameObject.GetComponent<SpriteRenderer>();
        shotgunScript = (GameObject.Find("PumpShotgun")).gameObject.GetComponent<PumpShotgun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Shotgun.transform.parent != WeaponsHolder)
        {
            shotgunScript.enabled = true;
            ShotgunSpriteRenderer.enabled = true;
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You got the Shotgun!";

            Shotgun.transform.SetParent(WeaponsHolder);
            weaponsOrder.Reoder();

            int currentPlace = Shotgun.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && Shotgun.transform.parent == WeaponsHolder)
        {
            Destroy(gameObject);
            //ammo pickup
        }

        else
        {
            return;
        }
    }
}

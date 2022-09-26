using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A1ShotgunPickup: MonoBehaviour
{
    public GameObject A1Shotgun;
    private SpriteRenderer A1ShotgunSpriteRenderer;
    private ShotgunScript A1shotgunScript;

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

        A1Shotgun = GameObject.Find("DBRShotgun");
        A1ShotgunSpriteRenderer = (GameObject.Find("DBRShotgun")).gameObject.GetComponent<SpriteRenderer>();
        A1shotgunScript = (GameObject.Find("DBRShotgun")).gameObject.GetComponent<ShotgunScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && A1Shotgun.transform.parent != WeaponsHolder)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You picked up the A1 Shotgun!";

            A1Shotgun.transform.SetParent(WeaponsHolder);


            weaponsOrder.Reoder();

            int currentPlace = A1Shotgun.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && A1Shotgun.transform.parent == WeaponsHolder)
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

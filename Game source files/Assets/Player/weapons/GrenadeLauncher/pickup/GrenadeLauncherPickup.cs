using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncherPickup : MonoBehaviour
{
    public GameObject GrenadeLauncher;
    private SpriteRenderer GLSpriteRenderer;
    private GrenadeLauncher GLScript;

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

        GrenadeLauncher = GameObject.Find("GrenadeLauncher");
        GLSpriteRenderer = (GameObject.Find("GrenadeLauncher")).gameObject.GetComponent<SpriteRenderer>();
        GLScript = (GameObject.Find("GrenadeLauncher")).gameObject.GetComponent<GrenadeLauncher>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GrenadeLauncher.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You got the Grenade Laucher!";

            GrenadeLauncher.transform.SetParent(WeaponsHolder);


            weaponsOrder.Reoder();

            int currentPlace = GrenadeLauncher.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && GrenadeLauncher.transform.parent == WeaponsHolder)
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RevolverPickup : MonoBehaviour
{
    public GameObject Revolver;
    private SpriteRenderer RevolverSpriteRenderer;
    private RevolverScript revolverScript;

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

        Revolver = GameObject.Find("Revolver");
        RevolverSpriteRenderer = (GameObject.Find("Revolver")).gameObject.GetComponent<SpriteRenderer>();
        revolverScript = (GameObject.Find("Revolver")).gameObject.GetComponent<RevolverScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Revolver.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You picked up the Revolver!";

            Revolver.transform.SetParent(WeaponsHolder);


            weaponsOrder.Reoder();

            int currentPlace = Revolver.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);

        }
        if (other.CompareTag("Player") && Revolver.transform.parent == WeaponsHolder)
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

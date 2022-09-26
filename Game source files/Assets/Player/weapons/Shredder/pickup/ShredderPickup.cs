using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShredderPickup : MonoBehaviour
{
    public GameObject Shredder;
    private SpriteRenderer ShredderSpriteRenderer;
    private Shredder shredderScript;

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

        Shredder = GameObject.Find("Shredder");
        ShredderSpriteRenderer = (GameObject.Find("Shredder")).gameObject.GetComponent<SpriteRenderer>();
        shredderScript = (GameObject.Find("Shredder")).gameObject.GetComponent<Shredder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Shredder.transform.parent != WeaponsHolder)
        {
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You picked up the Shredder!";


            Shredder.transform.SetParent(WeaponsHolder);

            weaponsOrder.Reoder();

            int currentPlace = Shredder.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && Shredder.transform.parent == WeaponsHolder)
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

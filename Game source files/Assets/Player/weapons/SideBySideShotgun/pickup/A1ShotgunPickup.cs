using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A1ShotgunPickup: MonoBehaviour
{
    public GameObject A1Shotgun;
    public Transform WeaponsHolder;

    public WeaponsNotiController WeaponPickupNoti;
    public Text WeaponsNoti;

    public SwitchWeapons switchWeapons;

    public WeaponsOrder weaponsOrder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && A1Shotgun.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.gameObject.SetActive(true);
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

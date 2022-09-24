using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpShotgunPickup : MonoBehaviour
{
    public GameObject Shotgun;
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
        if (other.CompareTag("Player") && Shotgun.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.gameObject.SetActive(true);
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

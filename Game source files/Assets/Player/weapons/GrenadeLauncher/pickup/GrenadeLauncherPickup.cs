using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncherPickup : MonoBehaviour
{
    public GameObject GrenadeLauncher;
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
        if (other.CompareTag("Player") && GrenadeLauncher.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.gameObject.SetActive(true);
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

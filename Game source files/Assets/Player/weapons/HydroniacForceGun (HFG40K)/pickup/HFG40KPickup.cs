using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HFG40KPickup : MonoBehaviour
{
    public GameObject HFG40K;
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
        if (other.CompareTag("Player") && HFG40K.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.gameObject.SetActive(true);
            WeaponsNoti.text = "You picked up the legendary HFG40K! Hell yeah!";

            HFG40K.transform.SetParent(WeaponsHolder);

            weaponsOrder.Reoder();

            int currentPlace = HFG40K.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();

            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && HFG40K.transform.parent == WeaponsHolder)
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

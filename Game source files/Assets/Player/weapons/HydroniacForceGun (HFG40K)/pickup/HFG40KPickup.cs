using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HFG40KPickup : MonoBehaviour
{
    public GameObject HFG40K;
    private SpriteRenderer HFGSpriteRenderer;
    private HFG40K HFGScript;

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

        HFG40K = GameObject.Find("HFG40K");
        HFGSpriteRenderer = (GameObject.Find("HFG40K")).gameObject.GetComponent<SpriteRenderer>();
        HFGScript = (GameObject.Find("HFG40K")).gameObject.GetComponent<HFG40K>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && HFG40K.transform.parent != WeaponsHolder)
        {

            WeaponsNoti.enabled = true;
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

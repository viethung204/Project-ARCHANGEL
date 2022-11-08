using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A1ShotgunPickup: MonoBehaviour
{
    public GameObject A1Shotgun;


    private Transform WeaponsHolder;

    private Text WeaponsNoti;
    private WeaponsNotiController notification;
    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;
    private LoadoutManager loadout;


    // Start is called before the first frame update
    void Start()
    {
        loadout = (GameObject.Find("LoadoutManager")).gameObject.GetComponent<LoadoutManager>();

        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();

        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && A1Shotgun.transform.parent != WeaponsHolder)
        {
            A1Shotgun.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You picked up the A1 Shotgun!";
            notification.textTimer = 0;
            A1Shotgun.transform.SetParent(WeaponsHolder);
            loadout.dbShotgunState = 1;

            weaponsOrder.Reorder();

            int currentPlace = A1Shotgun.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && A1Shotgun.transform.parent == WeaponsHolder)
        {
            AmmoManager.ShotgunInvAmmo += 10;
            Destroy(gameObject);
        }

        else
        {
            return;
        }
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}

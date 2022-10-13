using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpShotgunPickup : MonoBehaviour
{
    private GameObject Shotgun;


    private Transform WeaponsHolder;
    private AmmoManager ammoManager;

    private Text WeaponsNoti;
    private WeaponsNotiController notification;
    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;



    // Start is called before the first frame update
    void Start()
    {
        ammoManager = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<AmmoManager>();

        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();

        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

        Shotgun = FindInActiveObjectByName("PumpShotgun");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Shotgun.transform.parent != WeaponsHolder)
        {

            Shotgun.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You got the Shotgun!";
            notification.textTimer = 0;
            Shotgun.transform.SetParent(WeaponsHolder);
            weaponsOrder.Reoder();

            int currentPlace = Shotgun.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && Shotgun.transform.parent == WeaponsHolder)
        {
            ammoManager.ShotgunInvAmmo += 10;
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

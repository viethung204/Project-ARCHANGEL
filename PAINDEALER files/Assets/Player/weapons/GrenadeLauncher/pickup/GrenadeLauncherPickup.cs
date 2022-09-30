using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncherPickup : MonoBehaviour
{
    private GameObject GrenadeLauncher;


    private Transform WeaponsHolder;
    private AmmoManager ammoManager;

    private Text WeaponsNoti;

    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;


    // Start is called before the first frame update
    void Start()
    {
        ammoManager = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<AmmoManager>();

        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();


        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

        GrenadeLauncher = GameObject.Find("GrenadeLauncher");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GrenadeLauncher.transform.parent != WeaponsHolder)
        {
            GrenadeLauncher.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You got the Grenade Laucher!";

            GrenadeLauncher.transform.SetParent(WeaponsHolder);


            weaponsOrder.Reoder();

            int currentPlace = GrenadeLauncher.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && GrenadeLauncher.transform.parent == WeaponsHolder)
        {
            ammoManager.GLInvAmmo += 6;
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

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

    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;

    private MeshRenderer tint;

    // Start is called before the first frame update
    void Start()
    {
        ammoManager = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<AmmoManager>();

        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();


        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

        Shotgun = FindInActiveObjectByName("PumpShotgun");

        tint = (GameObject.Find("Tint")).gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Shotgun.transform.parent != WeaponsHolder)
        {
            tint.enabled = true;
            Shotgun.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You got the Shotgun!";

            Shotgun.transform.SetParent(WeaponsHolder);
            weaponsOrder.Reoder();

            int currentPlace = Shotgun.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && Shotgun.transform.parent == WeaponsHolder)
        {
            tint.enabled = true;
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

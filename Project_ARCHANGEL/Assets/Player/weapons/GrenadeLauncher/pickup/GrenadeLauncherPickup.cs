using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncherPickup : MonoBehaviour
{
    public GameObject GrenadeLauncher;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;
    private Transform WeaponsHolder;
    private AmmoManager ammoManager;

    private Text WeaponsNoti;
    private WeaponsNotiController notification;
    private SwitchWeapons switchWeapons;

    private WeaponsOrder weaponsOrder;
    private LoadoutManager loadout;


    // Start is called before the first frame update
    void Start()
    {
        loadout = (GameObject.Find("LoadoutManager")).gameObject.GetComponent<LoadoutManager>();
        ammoManager = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<AmmoManager>();

        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();

        switchWeapons = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<SwitchWeapons>();

        weaponsOrder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<WeaponsOrder>();
        PlayerCamera = Camera.main;
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GrenadeLauncher.transform.parent != WeaponsHolder)
        {
            GrenadeLauncher.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "picked up the Grenade Laucher!";
            notification.textTimer = 0;
            GrenadeLauncher.transform.SetParent(WeaponsHolder);
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            LoadoutManager.grenadeLauncherState = 1;
            weaponsOrder.Reorder();

            int currentPlace = GrenadeLauncher.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && GrenadeLauncher.transform.parent == WeaponsHolder)
        {
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            AmmoManager.GLInvAmmo += 6;
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

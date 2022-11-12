using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShredderPickup : MonoBehaviour
{
    public GameObject Shredder;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;
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

        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();

        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Shredder.transform.parent != WeaponsHolder)
        {

            Shredder.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "You picked up the Shredder!";
            notification.textTimer = 0;
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            Shredder.transform.SetParent(WeaponsHolder);
            LoadoutManager.shredderState = 1;
            weaponsOrder.Reorder();

            int currentPlace = Shredder.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && Shredder.transform.parent == WeaponsHolder)
        {
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            AmmoManager.ShredderInvAmmo += 50;
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

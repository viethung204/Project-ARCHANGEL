using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RevolverPickup : MonoBehaviour
{
    public GameObject Revolver;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    private Transform WeaponsHolder;
    private Camera PlayerCamera;
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
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Revolver.transform.parent != WeaponsHolder)
        {

            Revolver.SetActive(true);
            WeaponsNoti.enabled = true;
            WeaponsNoti.text = "picked up the Revolver!";
            notification.textTimer = 0;
            Revolver.transform.SetParent(WeaponsHolder);
            LoadoutManager.revolverState = 1;

            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            weaponsOrder.Reorder();

            int currentPlace = Revolver.transform.GetSiblingIndex();

            switchWeapons.selectedWeapon = currentPlace;
            switchWeapons.SelectWeapon();


            Destroy(gameObject);

        }
        else if (other.CompareTag("Player") && Revolver.transform.parent == WeaponsHolder)
        {
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            AmmoManager.RevolverInvAmmo += 12;
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

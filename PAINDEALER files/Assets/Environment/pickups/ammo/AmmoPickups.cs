using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickups : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;
    public string NotificationText;
    public int RevolverPU;
    public int ShotgunPU;
    public int GrenadeLauncherPU;
    public int ShredderPU;
    public int hfgPU;
    public int GrenadePU;

    private void Start()
    {
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        PlayerCamera = Camera.main;
    }

    private void Notify()
    {
        AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
        notiText.enabled = true;
        notiText.text = NotificationText;
        notification.textTimer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            if (RevolverPU > 0)
            {
                if(AmmoManager.RevolverInvAmmo < 200)
                {
                    Notify();
                    AmmoManager.RevolverInvAmmo += RevolverPU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
            if (ShotgunPU > 0)
            {
                if (AmmoManager.ShotgunInvAmmo < 50)
                {
                    Notify();
                    AmmoManager.ShotgunInvAmmo += ShotgunPU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
            if (ShredderPU > 0)
            {
                if (AmmoManager.ShredderInvAmmo < 200)
                {
                    Notify();
                    AmmoManager.ShredderInvAmmo += ShredderPU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
            if (GrenadeLauncherPU > 0)
            {
                if (AmmoManager.GLInvAmmo < 50)
                {
                    Notify();
                    AmmoManager.GLInvAmmo += GrenadeLauncherPU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
            if (hfgPU > 0)
            {
                if (AmmoManager.CoreInvAmmo < 200)
                {
                    Notify();
                    AmmoManager.CoreInvAmmo += hfgPU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
            if (GrenadePU > 0)
            {
                if (AmmoManager.grenadeCount < 200)
                {
                    Notify();
                    AmmoManager.grenadeCount += GrenadePU;
                    Destroy(gameObject);
                }
                else
                {
                    return;
                }
            }
        }
    }
}

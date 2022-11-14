using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supplyKit : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    playerHealth healthScript;
    public int ArmorPU;
    public int HealthPU;
    public int RevolverPU;
    public int ShotgunPU;
    public int GrenadeLauncherPU;
    public int ShredderPU;
    public int hfgPU;
    public int GrenadePU;
    public AudioClip PickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;
    public string NotificationText;

    // Start is called before the first frame update
    void Start()
    {
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        healthScript = GameObject.Find("Capsule").GetComponent<playerHealth>();
        PlayerCamera = Camera.main;
    }
    private void Notify()
    {
        notiText.enabled = true;
        notiText.text = NotificationText;
        notification.textTimer = 0;
        AudioSource.PlayClipAtPoint(PickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (healthScript.Health < 100)
            {
                Notify();
                healthScript.Health += HealthPU;
                Destroy(gameObject);
            }
            if (playerHealth.Armor < 100)
            {
                Notify();
                playerHealth.Armor += ArmorPU;
                Destroy(gameObject);
            }
            if (AmmoManager.RevolverInvAmmo < 200)
            {
                Notify();
                AmmoManager.RevolverInvAmmo += RevolverPU;
                Destroy(gameObject);
            }
            if (AmmoManager.ShotgunInvAmmo < 50)
            {
                Notify();
                AmmoManager.ShotgunInvAmmo += ShotgunPU;
                Destroy(gameObject);
            }
            if (AmmoManager.ShredderInvAmmo < 200)
            {
                Notify();
                AmmoManager.ShredderInvAmmo += ShredderPU;
                Destroy(gameObject);
            }
            if (AmmoManager.GLInvAmmo < 200)
            {
                Notify();
                AmmoManager.GLInvAmmo += GrenadeLauncherPU;
                Destroy(gameObject);
            }
            if (AmmoManager.CoreInvAmmo < 200)
            {
                Notify();
                AmmoManager.CoreInvAmmo += hfgPU;
                Destroy(gameObject);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class healthPickup : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    playerHealth healthScript;
    public int HealthPU;
    public AudioClip healthPickupAudio;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (healthScript.Health < 100)
            {
                notiText.enabled = true;
                notiText.text = NotificationText;
                notification.textTimer = 0;
                AudioSource.PlayClipAtPoint(healthPickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
                healthScript.Health += HealthPU;
                Destroy(gameObject);
            }
            else
            {
                return;
            }

        }
    }
}

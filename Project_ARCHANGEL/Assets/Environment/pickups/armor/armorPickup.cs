using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class armorPickup : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    public int ArmorPU;
    public AudioClip armorPickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;
    public string NotificationText;

    // Start is called before the first frame update
    void Start()
    {
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerHealth.Armor < 100)
            {
                notiText.enabled = true;
                notiText.text = NotificationText;
                notification.textTimer = 0;
                AudioSource.PlayClipAtPoint(armorPickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
                playerHealth.Armor += ArmorPU;
                Destroy(gameObject);
            }
            else
            {
                return;
            }

        }
    }
}

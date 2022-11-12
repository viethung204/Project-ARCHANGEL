using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUps : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    public AudioClip PickupAudio;
    private Camera PlayerCamera;
    public float AudioVolume = 10f;

    private void Start()
    {
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            notiText.enabled = true;
            notiText.text = "Picked up saint michael's crucifix!";
            AudioSource.PlayClipAtPoint(PickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            notification.textTimer = 0;
            playerHealth.powerUp = true;
            Destroy(gameObject);
        }
    }
}

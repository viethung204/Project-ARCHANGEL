using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioSuitScript : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;
    public AudioSource source;

    private void Start()
    {
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        source = (GameObject.Find("keysAudio")).gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            notiText.enabled = true;
            notiText.text = "Picked up a BiO suit!";
            notification.textTimer = 0;
            playerHealth.BioSuit = true;
            Destroy(gameObject);
        }
    }
}

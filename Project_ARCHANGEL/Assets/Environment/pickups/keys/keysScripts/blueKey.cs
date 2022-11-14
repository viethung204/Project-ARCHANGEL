using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blueKey : MonoBehaviour
{
    interactor keyCheck;
    private Text WeaponsNoti;
    private WeaponsNotiController notification;
    public AudioSource source;

    private void Start()
    {
        keyCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<interactor>();
        WeaponsNoti = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<Text>();
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
        source = (GameObject.Find("keysAudio")).gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponsNoti.enabled = true;
            notification.textTimer = 0;
            WeaponsNoti.text = "picked up the BLUE key.";
            source.Play();
            keyCheck.blueKey = true;
            Destroy(gameObject);

        }
    }
}
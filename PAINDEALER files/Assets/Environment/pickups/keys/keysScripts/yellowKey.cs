using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yellowKey : MonoBehaviour
{
    interactor keyCheck;
    public Text WeaponsNoti;
    public AudioSource source;
    private WeaponsNotiController notification;


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
            WeaponsNoti.text = "You picked up the YELLOW key";
            source.Play();
            keyCheck.yellowKey = true;
            Destroy(gameObject);

        }
    }
}
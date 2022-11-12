using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioSuitScript : MonoBehaviour
{
    Text notiText;
    private WeaponsNotiController notification;

    private void Start()
    {
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notiText.enabled = true;
            notiText.text = "Picked up a BiO suit!";
            notification.textTimer = 0;
            playerHealth.BioSuit = true;
            Destroy(gameObject);
        }
    }
}

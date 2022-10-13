using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioSuitScript : MonoBehaviour
{
    playerHealth BioSuitCheck;
    Text notiText;
    private WeaponsNotiController notification;

    private void Start()
    {
        BioSuitCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerHealth>();
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
        notification = (GameObject.Find("weaponsNoti")).gameObject.GetComponent<WeaponsNotiController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notiText.enabled = true;
            notiText.text = "You picked up a BiO suit!";
            notification.textTimer = 0;
            BioSuitCheck.BioSuit = true;
            Destroy(gameObject);
        }
    }
}

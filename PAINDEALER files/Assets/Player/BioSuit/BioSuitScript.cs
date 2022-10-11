using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioSuitScript : MonoBehaviour
{
    playerHealth BioSuitCheck;
    Text notiText;
    
    private void Start()
    {
        BioSuitCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerHealth>();
        notiText = GameObject.Find("weaponsNoti").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notiText.enabled = true;
            notiText.text = "You picked up a BiO suit!";
            BioSuitCheck.BioSuit = true;
            Destroy(gameObject);
        }
    }
}

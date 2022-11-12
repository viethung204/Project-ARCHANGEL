using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class biosuitFilterScript : MonoBehaviour
{
    Image greenImage;

    private void Start()
    {
        greenImage = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (playerHealth.BioSuit == true)
        {
            greenImage.enabled = true;
        }
        else
        {
            greenImage.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redKeyIcon : MonoBehaviour
{
    Image spriteRenderer;
    interactor keyCheck;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        keyCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCheck.redKey == true)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}

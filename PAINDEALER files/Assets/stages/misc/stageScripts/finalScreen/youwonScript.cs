using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class youwonScript : MonoBehaviour
{

    TextMeshProUGUI txt;
    string story;
    public GameObject nextButton;

    void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
        story = txt.text;
        txt.text = "";

        // TODO: add optional delay when to start
        StartCoroutine("PlayText");

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            txt.text = story;
            StopAllCoroutines();
            nextButton.SetActive(true);
        }
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.07f);
        }
    }

}


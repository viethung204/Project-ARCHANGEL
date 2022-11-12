using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class warnTextManager : MonoBehaviour
{
    public TextMeshProUGUI warnText;
    public static float textTimer = 0; // timer, starts when text first appear
    public int textTime = 3; //the amount of time text stay on b4 off;

    private void Update()
    {
        if (textTimer > textTime)
        {
            warnText.enabled = false;
        }
        if (warnText.enabled == true)
        {
            textTimer += Time.deltaTime;
        }
        if (warnText.enabled == false)
        {
            textTimer = 0;
            textTime = 3;
        }
    }
}

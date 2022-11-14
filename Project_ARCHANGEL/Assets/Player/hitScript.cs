using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class hitScript : MonoBehaviour
{

    private void Update()
    {
        if(GetComponent<Image>().color.a > 0)
        {
            var color = GetComponent<Image>().color;
            color.a -= 0.005f;
            GetComponent<Image>().color = color;
        }
    }
}

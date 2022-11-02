using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triangleControl : MonoBehaviour
{
    public Image triangle;

    public void triangleOn()
    {
        triangle.enabled = true;
    }

    public void triangleOff()
    {
        triangle.enabled = false;
    }
}

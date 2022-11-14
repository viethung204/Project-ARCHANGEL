using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;
using JetBrains.Annotations;

public class GrenadeThrow : MonoBehaviour
{

    public Image CrosshairUI;
    public Sprite GrenadeCrosshair;

    private void Start()
    {
        CrosshairUI.GetComponent<Image>().sprite = GrenadeCrosshair;
    }

}

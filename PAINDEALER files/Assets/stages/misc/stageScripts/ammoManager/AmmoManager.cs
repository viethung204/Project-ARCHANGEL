using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static int RevolverInvAmmo;
    public static int ShotgunInvAmmo;
    public static int ShredderInvAmmo;
    public static int CoreInvAmmo;
    public static int GLInvAmmo;
    public static int grenadeCount;


    public void Update()
    {
        PlayerPrefs.SetInt("revolverInvAmmo", RevolverInvAmmo);
        PlayerPrefs.SetInt("ShotgunInvAmmo", ShotgunInvAmmo);
        PlayerPrefs.SetInt("GLInvAmmo", GLInvAmmo);
        PlayerPrefs.SetInt("ShredderInvAmmo", ShredderInvAmmo);
        PlayerPrefs.SetInt("HFGInvAmmo", CoreInvAmmo);
        PlayerPrefs.SetInt("Grenade", grenadeCount);
    }
}

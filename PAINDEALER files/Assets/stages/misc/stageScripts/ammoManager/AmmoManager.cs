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

    private void Update()
    {
        if(RevolverInvAmmo > 200)
        {
            RevolverInvAmmo = 200;
        }
        if(ShotgunInvAmmo > 50)
        {
            ShotgunInvAmmo = 50;
        }
        if(ShredderInvAmmo > 200)
        {
            ShredderInvAmmo = 200;
        }
        if (GLInvAmmo > 50)
        {
            GLInvAmmo = 50;
        }
        if (CoreInvAmmo > 5)
        {
            CoreInvAmmo = 5;
        }
        if (grenadeCount > 5)
        {
            grenadeCount = 5;
        }
    }
}

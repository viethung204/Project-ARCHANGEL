using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstStageAmmo : MonoBehaviour
{

    private void Start()
    {
        AmmoManager.RevolverInvAmmo = 18;
        AmmoManager.ShotgunInvAmmo = 5;
        AmmoManager.ShredderInvAmmo = 50;
        AmmoManager.GLInvAmmo = 5;
        AmmoManager.CoreInvAmmo = 1;
        AmmoManager.grenadeCount = 3;
    }
}

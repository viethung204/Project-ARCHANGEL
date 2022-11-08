using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStageAmmo : MonoBehaviour
{

    private void Start()
    {
        AmmoManager.RevolverInvAmmo = PlayerPrefs.GetInt("revolverInvAmmo");
        AmmoManager.ShotgunInvAmmo = PlayerPrefs.GetInt("ShotgunInvAmmo");
        AmmoManager.ShredderInvAmmo = PlayerPrefs.GetInt("ShredderInvAmmo");
        AmmoManager.GLInvAmmo = PlayerPrefs.GetInt("GLInvAmmo");
        AmmoManager.CoreInvAmmo = PlayerPrefs.GetInt("HFGInvAmmo");
        AmmoManager.grenadeCount = PlayerPrefs.GetInt("Grenade");
    }
}

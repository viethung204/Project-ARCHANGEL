using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("revolverInvAmmoOld", AmmoManager.RevolverInvAmmo);
        PlayerPrefs.SetInt("ShotgunInvAmmoOld", AmmoManager.ShotgunInvAmmo);
        PlayerPrefs.SetInt("GLInvAmmoOld", AmmoManager.GLInvAmmo);
        PlayerPrefs.SetInt("ShredderInvAmmoOld", AmmoManager.ShredderInvAmmo);
        PlayerPrefs.SetInt("HFGInvAmmoOld", AmmoManager.CoreInvAmmo);
        PlayerPrefs.SetInt("GrenadeOld", AmmoManager.grenadeCount);
    }


}

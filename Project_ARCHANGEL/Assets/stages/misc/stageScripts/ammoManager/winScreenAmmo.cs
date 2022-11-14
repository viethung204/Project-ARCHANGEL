using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScreenAmmo : MonoBehaviour
{
    public void UpdateNewAmmo()
    {
        PlayerPrefs.SetInt("revolverInvAmmo", AmmoManager.RevolverInvAmmo);
        PlayerPrefs.SetInt("ShotgunInvAmmo", AmmoManager.ShotgunInvAmmo);
        PlayerPrefs.SetInt("GLInvAmmo", AmmoManager.GLInvAmmo);
        PlayerPrefs.SetInt("ShredderInvAmmo", AmmoManager.ShredderInvAmmo);
        PlayerPrefs.SetInt("HFGInvAmmo", AmmoManager.CoreInvAmmo);
        PlayerPrefs.SetInt("Grenade", AmmoManager.grenadeCount);

        AmmoManager.RevolverInvAmmo = PlayerPrefs.GetInt("revolverInvAmmo");
        AmmoManager.ShotgunInvAmmo = PlayerPrefs.GetInt("ShotgunInvAmmo");
        AmmoManager.ShredderInvAmmo = PlayerPrefs.GetInt("ShredderInvAmmo");
        AmmoManager.GLInvAmmo = PlayerPrefs.GetInt("GLInvAmmo");
        AmmoManager.CoreInvAmmo = PlayerPrefs.GetInt("HFGInvAmmo");
        AmmoManager.grenadeCount = PlayerPrefs.GetInt("Grenade");
    }

    public void UpdateOldAmmo()
    {
        AmmoManager.RevolverInvAmmo = PlayerPrefs.GetInt("revolverInvAmmoOld");
        AmmoManager.ShotgunInvAmmo = PlayerPrefs.GetInt("ShotgunInvAmmoOld");
        AmmoManager.ShredderInvAmmo = PlayerPrefs.GetInt("ShredderInvAmmoOld");
        AmmoManager.GLInvAmmo = PlayerPrefs.GetInt("GLInvAmmoOld");
        AmmoManager.CoreInvAmmo = PlayerPrefs.GetInt("HFGInvAmmoOld");
        AmmoManager.grenadeCount = PlayerPrefs.GetInt("GrenadeOld");
    }
}

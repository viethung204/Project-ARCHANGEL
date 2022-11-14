using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentAmmoManager : MonoBehaviour
{
    public void UpdateNewCurrent()
    {
        PlayerPrefs.SetInt("revolverCurrentAmmo", RevolverScript.RevolverCurrentAmmo);
        PlayerPrefs.SetInt("ShotgunCurrentAmmo", PumpShotgun.CurrentAmmo);
        PlayerPrefs.SetInt("DBShotgunCurrentAmmo", ShotgunScript.CurrentAmmo);

        RevolverScript.RevolverCurrentAmmo = PlayerPrefs.GetInt("revolverCurrentAmmo");
        PumpShotgun.CurrentAmmo = PlayerPrefs.GetInt("ShotgunCurrentAmmo");
        ShotgunScript.CurrentAmmo = PlayerPrefs.GetInt("DBShotgunCurrentAmmo");
    }
    public void UpdateOldCurrent()
    {
        RevolverScript.RevolverCurrentAmmo = PlayerPrefs.GetInt("revolverCurrentAmmoOld");
        PumpShotgun.CurrentAmmo = PlayerPrefs.GetInt("ShotgunCurrentAmmoOld");
        ShotgunScript.CurrentAmmo = PlayerPrefs.GetInt("DBShotgunCurrentAmmoOld");
    }
}

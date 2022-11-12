using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldCurrentAmmo : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("revolverCurrentAmmoOld", RevolverScript.RevolverCurrentAmmo);
        PlayerPrefs.SetInt("ShotgunCurrentAmmoOld", PumpShotgun.CurrentAmmo);
        PlayerPrefs.SetInt("DBShotgunCurrentAmmoOld", ShotgunScript.CurrentAmmo);
    }
}

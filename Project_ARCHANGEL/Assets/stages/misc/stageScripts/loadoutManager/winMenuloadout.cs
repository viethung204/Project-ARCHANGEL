using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winMenuloadout : MonoBehaviour
{
    public void UpdateNewWeapon()
    {
        PlayerPrefs.SetInt("revolverKey", LoadoutManager.revolverState);
        PlayerPrefs.SetInt("pumpShotgunKey", LoadoutManager.pumpShotgunState);
        PlayerPrefs.SetInt("DoubleBarrelShotgunKey", LoadoutManager.dbShotgunState);
        PlayerPrefs.SetInt("GrenadeLauncherKey", LoadoutManager.grenadeLauncherState);
        PlayerPrefs.SetInt("ShredderKey", LoadoutManager.shredderState);
        PlayerPrefs.SetInt("HFGKey", LoadoutManager.hfgState);

        LoadoutManager.revolverState = PlayerPrefs.GetInt("revolverKey");
        LoadoutManager.pumpShotgunState = PlayerPrefs.GetInt("pumpShotgunKey");
        LoadoutManager.dbShotgunState = PlayerPrefs.GetInt("DoubleBarrelShotgunKey");
        LoadoutManager.grenadeLauncherState = PlayerPrefs.GetInt("GrenadeLauncherKey");
        LoadoutManager.shredderState = PlayerPrefs.GetInt("ShredderKey");
        LoadoutManager.hfgState = PlayerPrefs.GetInt("HFGKey");
    }

    public void UpdateOldWeapon()
    {
        LoadoutManager.revolverState = PlayerPrefs.GetInt("revolverKeyOld");
        LoadoutManager.pumpShotgunState = PlayerPrefs.GetInt("pumpShotgunKeyOld");
        LoadoutManager.dbShotgunState = PlayerPrefs.GetInt("DoubleBarrelShotgunKeyOld");
        LoadoutManager.grenadeLauncherState = PlayerPrefs.GetInt("GrenadeLauncherKeyOld");
        LoadoutManager.shredderState = PlayerPrefs.GetInt("ShredderKeyOld");
        LoadoutManager.hfgState = PlayerPrefs.GetInt("HFGKeyOld");

    }
}

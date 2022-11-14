using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldLoadout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("revolverKeyOld", LoadoutManager.revolverState);
        PlayerPrefs.SetInt("pumpShotgunKeyOld", LoadoutManager.pumpShotgunState);
        PlayerPrefs.SetInt("DoubleBarrelShotgunKeyOld", LoadoutManager.dbShotgunState);
        PlayerPrefs.SetInt("GrenadeLauncherKeyOld", LoadoutManager.grenadeLauncherState);
        PlayerPrefs.SetInt("ShredderKeyOld", LoadoutManager.shredderState);
        PlayerPrefs.SetInt("HFGKeyOld", LoadoutManager.hfgState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutManager : MonoBehaviour
{
    public GameObject revolver;
    public GameObject pumpShotgun;
    public GameObject dbShotgun;
    public GameObject grenadeLauncher;
    public GameObject shredder;
    public GameObject hfg;

    public int revolverState;
    public int pumpShotgunState;
    public int dbShotgunState;
    public int grenadeLauncherState;
    public int shredderState;
    public int hfgState;

    private Transform WeaponsHolder;
    private Transform idleWeapons;

    private void Start()
    {
        idleWeapons = (GameObject.Find("IdleWeapons")).gameObject.GetComponent<Transform>();
        WeaponsHolder = (GameObject.Find("Weapons Holder")).gameObject.GetComponent<Transform>();
        
        revolverState = PlayerPrefs.GetInt("revolverKey");
        pumpShotgunState = PlayerPrefs.GetInt("pumpShotgunKey");
        dbShotgunState = PlayerPrefs.GetInt("DoubleBarrelShotgunKey");
        grenadeLauncherState = PlayerPrefs.GetInt("GrenadeLauncherKey");
        shredderState = PlayerPrefs.GetInt("ShredderKey");
        hfgState = PlayerPrefs.GetInt("HFGKey");
        
        //REVOLVER
        if (revolverState == 1)
        {
            revolver.transform.SetParent(WeaponsHolder);
        }
        else
        {
            revolver.transform.SetParent(idleWeapons);
        }


        //PumpShotgun
        if (pumpShotgunState == 1)
        {
            pumpShotgun.transform.SetParent(WeaponsHolder);
        }
        else
        {
            pumpShotgun.transform.SetParent(idleWeapons);
        }
        //DoubleBarrelShotgun
        if (dbShotgunState == 1)
        {
            dbShotgun.transform.SetParent(WeaponsHolder);
        }
        else
        {
            dbShotgun.transform.SetParent(idleWeapons);
        }
        //GrenadeLauncher
        if (grenadeLauncherState == 1)
        {
            grenadeLauncher.transform.SetParent(WeaponsHolder);
        }
        else
        {
            grenadeLauncher.transform.SetParent(idleWeapons);
        }
        //Shredder
        if (shredderState == 1)
        {
            shredder.transform.SetParent(WeaponsHolder);
        }
        else
        {
            shredder.transform.SetParent(idleWeapons);
        }
        //HFG40K
        if (hfgState == 1)
        {
            hfg.transform.SetParent(WeaponsHolder);
        }
        else
        {
            hfg.transform.SetParent(idleWeapons);
        }
    }

    public void UpdateWeapon()
    {
        PlayerPrefs.SetInt("revolverKey", revolverState);
        PlayerPrefs.SetInt("pumpShotgunKey", pumpShotgunState);
        PlayerPrefs.SetInt("DoubleBarrelShotgunKey", dbShotgunState);
        PlayerPrefs.SetInt("GrenadeLauncherKey", grenadeLauncherState);
        PlayerPrefs.SetInt("ShredderKey", shredderState);
        PlayerPrefs.SetInt("HFGKey", hfgState);
    }
}

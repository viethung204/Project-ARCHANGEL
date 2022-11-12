using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class firstStageLoadout : MonoBehaviour
{
    private Transform idleWeapons;

    public GameObject revolver;
    public GameObject pumpShotgun;
    public GameObject dbShotgun;
    public GameObject grenadeLauncher;
    public GameObject shredder;
    public GameObject hfg;

    void Start()
    {
        idleWeapons = (GameObject.Find("IdleWeapons")).gameObject.GetComponent<Transform>();
        revolver.transform.SetParent(idleWeapons);
        pumpShotgun.transform.SetParent(idleWeapons);
        dbShotgun.transform.SetParent(idleWeapons);
        grenadeLauncher.transform.SetParent(idleWeapons);
        shredder.transform.SetParent(idleWeapons);
        hfg.transform.SetParent(idleWeapons);

        LoadoutManager.revolverState = 0;
        LoadoutManager.dbShotgunState = 0;
        LoadoutManager.pumpShotgunState = 0;
        LoadoutManager.grenadeLauncherState = 0;
        LoadoutManager.shredderState = 0;
        LoadoutManager.hfgState = 0;
    }
}

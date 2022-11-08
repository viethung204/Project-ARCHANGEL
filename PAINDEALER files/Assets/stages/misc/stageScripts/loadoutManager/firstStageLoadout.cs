using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class firstStageLoadout : MonoBehaviour
{
    private LoadoutManager loadout;
    private Transform idleWeapons;

    public GameObject revolver;
    public GameObject pumpShotgun;
    public GameObject dbShotgun;
    public GameObject grenadeLauncher;
    public GameObject shredder;
    public GameObject hfg;

    void Start()
    {
        loadout = (GameObject.Find("LoadoutManager")).gameObject.GetComponent<LoadoutManager>();
        idleWeapons = (GameObject.Find("IdleWeapons")).gameObject.GetComponent<Transform>();
        revolver.transform.SetParent(idleWeapons);
        pumpShotgun.transform.SetParent(idleWeapons);
        dbShotgun.transform.SetParent(idleWeapons);
        grenadeLauncher.transform.SetParent(idleWeapons);
        shredder.transform.SetParent(idleWeapons);
        hfg.transform.SetParent(idleWeapons);

        loadout.revolverState = 0;
        loadout.dbShotgunState = 0;
        loadout.pumpShotgunState = 0;
        loadout.grenadeLauncherState = 0;
        loadout.shredderState = 0;
        loadout.hfgState = 0;
    }
}

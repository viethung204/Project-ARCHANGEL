using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsOrder : MonoBehaviour
{
    public GameObject Revolver;
    public GameObject PumpShotgun;
    public GameObject A1Shotgun;
    public GameObject GrenadeLauncher;
    public GameObject Shredder;
    public GameObject HFG40K;

    public void Reorder()
    {
        Revolver.transform.SetSiblingIndex(1);
        PumpShotgun.transform.SetSiblingIndex(2);
        A1Shotgun.transform.SetSiblingIndex(3);
        GrenadeLauncher.transform.SetSiblingIndex(4);
        Shredder.transform.SetSiblingIndex(5);
        HFG40K.transform.SetSiblingIndex(6);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateOFire : MonoBehaviour
{
    public Shredder Ammo;

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireOne()
    {
        Ammo.ShredderInvAmmo--;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectileScript : MonoBehaviour
{
    public float lifespan = 5f;

    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventGib : MonoBehaviour
{
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health < 0f)
        {
            health.health = 0;
        }
    }
}

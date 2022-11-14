using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    private new Light light;
    public float intensity1;
    public float intensity2;
    public float intensity3;
    public float intensity4;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    void Intensity1()
    {
        light.intensity = intensity1;
    }

    void Intensity2()
    {
        light.intensity = intensity2;
    }

    void Intensity3()
    {
        light.intensity = intensity3;
    }

    void Intensity4()
    {
        light.intensity = intensity4;
    }
}

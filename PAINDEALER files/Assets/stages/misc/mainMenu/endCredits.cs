using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCredits : MonoBehaviour
{
    public GameObject CreditsHolder;
    public GameObject MainHolder;
    public GameObject Archangel;
    public GameObject project;
    public GameObject logo;

    public void end()
    {
        CreditsHolder.active = false;
        MainHolder.active = true;
        project.active = true;
        Archangel.active = true;
        logo.active = true;
    }
}

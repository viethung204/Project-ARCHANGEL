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
        CreditsHolder.SetActive(false);
        MainHolder.SetActive(true);
        project.SetActive(true);
        Archangel.SetActive(true);
        logo.SetActive(true);
    }
}

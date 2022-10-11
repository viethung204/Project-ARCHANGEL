using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biosuitFilterScript : MonoBehaviour
{
    playerHealth filterCheck;
    MeshRenderer meshRenderer;

    private void Start()
    {
        filterCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerHealth>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (filterCheck.BioSuit == true)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}

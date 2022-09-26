using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tint : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            StartCoroutine(Tinting());
        }
    }

    public IEnumerator Tinting()
    {

        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}

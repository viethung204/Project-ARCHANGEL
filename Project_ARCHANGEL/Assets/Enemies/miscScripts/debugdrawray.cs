using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugdrawray : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
    }


}

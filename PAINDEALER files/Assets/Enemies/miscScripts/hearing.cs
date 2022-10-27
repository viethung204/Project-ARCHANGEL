using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearing : MonoBehaviour
{
    public float hearingDistance = 50f;
    public bool shotfired = false;
    private Transform TargetTransform;
    FieldOfView fovScript;


    // Start is called before the first frame update
    void Start()
    {
        TargetTransform = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
        fovScript = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Alert()
    {
        if (Vector3.Distance(transform.position, TargetTransform.position) < hearingDistance && shotfired == true)
        {
            fovScript.angle = 360f;
        }
    }
    
}

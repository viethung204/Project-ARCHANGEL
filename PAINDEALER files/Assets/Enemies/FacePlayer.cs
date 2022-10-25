using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform TargetTransform;
    public float RotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        TargetTransform = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = TargetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime
            * RotationSpeed);
    }
}

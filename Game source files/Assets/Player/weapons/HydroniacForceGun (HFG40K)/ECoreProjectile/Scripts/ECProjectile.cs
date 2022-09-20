using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECProjectile : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        thisRigidbody.AddForce(thisRigidbody.transform.forward * speed);
    }
}

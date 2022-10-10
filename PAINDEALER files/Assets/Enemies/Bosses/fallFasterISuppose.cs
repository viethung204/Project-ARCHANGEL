using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallFasterISuppose : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rigidbody;

    public bool usingGravity;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        usingGravity = rigidbody.useGravity;
    }

    void FixedUpdate()
    {
        if (rigidbody.useGravity) rigidbody.AddForce(Physics.gravity * (rigidbody.mass));
    }
}

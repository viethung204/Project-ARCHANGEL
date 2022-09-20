using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectileScript : MonoBehaviour
{
    public float speed = 200f;
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

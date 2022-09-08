using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour
{

    public Transform MyCameraTransform;
    private Transform MyTransform;
    public bool alignNotLook = true;
    float lockPos = 0;

    // Use this for initialization
    void Start()
    {
        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);

        transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

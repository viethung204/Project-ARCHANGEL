using UnityEngine;

public class Recoil : MonoBehaviour
{

    public  Vector3 currentRotation;
    public Vector3 targetRotation;
 
    public float RecoilX;
    public float RecoilY;
    public float  RecoilZ;

     public float snappiness;
     public float returnSpeed;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        targetRotation = new Vector3(RecoilX, Random.Range(-RecoilY, RecoilY), Random.Range(-RecoilZ, RecoilZ));
    }
}

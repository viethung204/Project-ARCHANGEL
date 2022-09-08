using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    public float AmmoPU = 5f;
    public ShotgunScript shotgunScript;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    public Camera PlayerCamera;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            shotgunScript.GetComponent<ShotgunScript>();
            shotgunScript.InvAmmo += AmmoPU;
            Destroy(gameObject);
            
        }
    }
}

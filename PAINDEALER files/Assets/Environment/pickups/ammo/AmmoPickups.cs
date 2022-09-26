using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    public int AmmoPU = 5;
    public ShotgunScript shotgunScript;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    public Camera PlayerCamera;

    private MeshRenderer tint;


    private void Start()
    {
        tint = (GameObject.Find("Tint")).gameObject.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tint.enabled = true;
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            AmmoManager ammoManager = (GameObject.Find("Weapons Holder")).GetComponent<AmmoManager>();
            ammoManager.ShotgunInvAmmo += AmmoPU;
            Destroy(gameObject);
            
        }
    }
}

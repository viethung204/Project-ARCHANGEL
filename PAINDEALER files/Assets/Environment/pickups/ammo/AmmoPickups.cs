using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    public int AmmoPU = 5;
    public AudioClip pickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;

    private void Start()
    {
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
            AmmoManager ammoManager = (GameObject.Find("Weapons Holder")).GetComponent<AmmoManager>();
            AmmoManager.ShotgunInvAmmo += AmmoPU;
            Destroy(gameObject);
            
        }
    }
}

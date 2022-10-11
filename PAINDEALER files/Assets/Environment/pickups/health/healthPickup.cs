using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    playerHealth healthScript;
    public int HealthPU = 30;
    public AudioClip healthPickupAudio;
    public float AudioVolume = 10f;
    private Camera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerHealth>();
        PlayerCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (healthScript.Health < 100)
            {
                AudioSource.PlayClipAtPoint(healthPickupAudio, PlayerCamera.gameObject.transform.position, AudioVolume);
                healthScript.Health += HealthPU;
                Destroy(gameObject);
            }
            else
            {
                return;
            }

        }
    }
}

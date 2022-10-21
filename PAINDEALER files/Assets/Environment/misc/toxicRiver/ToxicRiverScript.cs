using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicRiverScript : MonoBehaviour
{
    playerHealth healthScript;
    public Collider playerCollider;
    float collideTimer = 0; // timer, starts when the player first collides with the river
    int timeDMG = 2; //the amount of time player can stay on river b4 take damage;

    private void Start()
    {
        healthScript = GameObject.Find("Capsule").GetComponent<playerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collideTimer = 0;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider == playerCollider && healthScript.BioSuit == false)
        {
            if(collideTimer < timeDMG)
            {
                collideTimer += Time.deltaTime; //continue to add real-world time(?) if the timer is lower than the threshold
            }
            else
            {
                DeadDelay();
                collideTimer = 0; //reset the timer
            }
        }
    }
    
    void DeadDelay()
    {
        healthScript.Health -= 5;
    }
}

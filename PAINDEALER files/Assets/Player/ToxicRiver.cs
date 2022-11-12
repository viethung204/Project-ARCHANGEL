using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicRiver : MonoBehaviour
{
    public playerHealth healthScript;
    float collideTimer = 0; // timer, starts when the player first collides with the river
    int timeDMG = 2; //the amount of time player can stay on river b4 take damage;

    private void OnCollisionEnter(Collision col)
    {
        collideTimer = 0;
        if(col.gameObject.CompareTag("toxic"))
        {
            Debug.Log("fuckyou");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("toxic"))
        {
            Debug.Log("fuckyou");
        }

        if (collision.gameObject.CompareTag("toxic") && playerHealth.BioSuit == false)
        {
            Debug.Log("touched");
            if (collideTimer < timeDMG)
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
        healthScript.Health -= 10;
    }
}

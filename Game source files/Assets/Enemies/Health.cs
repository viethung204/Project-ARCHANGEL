using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public Animator EnemyAnimator;
    public Transform Player;
    public float travelSpeed;
    public float deceleration;

    /*public BoxCollider Collider;
    public float newColliderX;
    public float newColliderY;*/

    public void TakeDamage(float amount)
    {
        health -= amount;
        EnemyAnimator.SetTrigger("isHurt");
    }

    void Update()
    {
        
        if (health <= 0f)
        {
            EnemyAnimator.SetBool("died", true);
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, transform.position += Player.forward, travelSpeed*Time.deltaTime);
            travelSpeed -= deceleration * Time.deltaTime;
            if (travelSpeed <= 0)
            {
                travelSpeed = 0;

            } 
        }
    }

}

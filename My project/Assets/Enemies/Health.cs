using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public Animator EnemyAnimator;
    /*public BoxCollider Collider;
    public float newColliderX;
    public float newColliderY;*/

    public void TakeDamage(float amount)
    {
        health -= amount;
        EnemyAnimator.SetTrigger("isHurt");

        if (health <= 0f) //dont call this on update to save memory
        {
            EnemyAnimator.SetBool("died", true);
            gameObject.tag = "Untagged";
         
            //Collider.size = new Vector3(newColliderX, newColliderY);
        }
    }
   
}

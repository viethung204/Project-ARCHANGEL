using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour
{
    public float health = 50f;
    private Animator EnemyAnimator;
    private Transform Player;
    public float deceleration = 1.5f;
    public float travelSpeed = 1.5f;
    public float gibThreshold = -5f;

    [Tooltip("0 has the lowest chance, 10 has the highest chance")]
    [Range(0.0f, 10f)]
    public float chanceForHurtAnimation;


    /*public BoxCollider Collider;
    public float newColliderX;
    public float newColliderY;*/

    private void Start()
    {
        EnemyAnimator = this.gameObject.GetComponent<Animator>();
        Player = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        float HurtAnimChance = Random.Range(0f, 10f);
        if(health > 0 && HurtAnimChance <= chanceForHurtAnimation) 
        { 
            EnemyAnimator.SetTrigger("isHurt"); 
        }
        
    }

    public void Update()
    {
        if (health <= 0f && health > gibThreshold)
        {
            EnemyAnimator.SetBool("died", true);
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, transform.position += Player.forward, travelSpeed * Time.deltaTime);
            if ((travelSpeed -= deceleration * Time.deltaTime) <= 0)
            {
                travelSpeed = 0;
            }
        }
        else if (health <= gibThreshold )
        {
            EnemyAnimator.SetBool("gibbed", true);
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, transform.position += Player.forward, travelSpeed * Time.deltaTime);
            if ((travelSpeed -= deceleration * Time.deltaTime) <= 0)
            {
                travelSpeed = 0;
            }
        }
    }
}

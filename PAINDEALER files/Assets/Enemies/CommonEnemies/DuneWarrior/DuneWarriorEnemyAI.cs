using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class DuneWarriorEnemyAI : MonoBehaviour
{
    public float agentSpeed;
    private Transform TargetTransform;
    public float RotationSpeed;
    public float minimumDistance;
    public float maximumDistance;
    NavMeshAgent agent;
    public float Damage = 5;
    public float range = 500f;

    FieldOfView fovScript;

    Animator eAnimator;
    Health health;

    int animLayer = 0;

    hearing hearing;

    public bool seen = false;
    
    // Update is called once per frame
    void Start()
    {
        fovScript = GetComponent<FieldOfView>();
        eAnimator = GetComponent<Animator>();
        TargetTransform = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
        health = gameObject.GetComponent<Health>();
        hearing = gameObject.GetComponent<hearing>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.speed = agentSpeed;
        hearing.Alert();
        if(isPlaying(eAnimator,"Hurt Blend Tree") || isPlaying(eAnimator, "Atk Blend Tree"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

        if(health.health <= 0)
        {
            this.enabled = false;
        }
        if (fovScript.canSeePlayer == true )
        {
            seen = true;
            fovScript.angle = 360f;
            ChaseAfterPlayer();
        }
        if (seen == true && fovScript.canSeePlayer == false)
        {
            ChaseAfterPlayer();
        }

         if (Vector3.Distance(transform.position, TargetTransform.position) <= maximumDistance && fovScript.canSeePlayer == true) 
         {
             FacingPlayer();
             AttackPlayerPose();
         }
         else
         {
             eAnimator.SetBool("isAttacking", false);
         }

        //enemy activated if player get too close
        if (Vector3.Distance(transform.position, TargetTransform.position) < minimumDistance)
        {
            fovScript.angle = 360f;
        }
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
    }
    //Note bcuz 4 some reason I get confused by this: minimumDistance < currentDistance < maximumDistance

    //ChasingScript: If distance from this bot to player is greater than maximumDistance, then chase after the Player
    void ChaseAfterPlayer()
    {
        if(!isPlaying(eAnimator, "Atk Blend Tree"))
        {
            agent.isStopped = false;
            if (Vector3.Distance(transform.position, TargetTransform.position) > maximumDistance && !isPlaying(eAnimator, "Hurt Blend Tree"))
            {
                eAnimator.SetBool("isAttacking", false);
                FacingPlayer();
                agent.SetDestination(TargetTransform.position);
            }
            else
            {
                FacingPlayer();
            }
        }
        
    }

    //Look at player with lerp to control the rotation speed
    void FacingPlayer()
    {
        Vector3 relativePos = TargetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime
            * RotationSpeed);
    }

    void AttackPlayerPose()
    {
        agent.isStopped = true;
        eAnimator.SetBool("isAttacking", true);
        FacingPlayer();
    }

    void AttackPlayer()
    {
        RaycastHit Hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out Hit, range))
        {
            playerHealth target = Hit.transform.GetComponent<playerHealth>();
            if (target != null)
            {
                target.Health -= Damage;
            }
        }
    }


    //check if animtion is playing
    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}

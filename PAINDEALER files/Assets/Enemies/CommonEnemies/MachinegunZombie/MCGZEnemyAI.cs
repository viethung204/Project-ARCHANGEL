using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class MCGZEnemyAI : MonoBehaviour
{
    public float RunningSpeed;
    private Transform TargetTransform;
    public float RotationSpeed;
    public float minimumDistance;
    public float maximumDistance;
    NavMeshAgent agent;
    public float Damage = 5;
    public bool attacked = false;
    public float range = 500f;

    FieldOfView fovScript;

    Animator eAnimator;
    Health health;

    public float radius = 5;
    public GetPoint getpoint;
    int animLayer = 0;

    hearing hearing;

    // Update is called once per frame
    void Start()
    {
        fovScript = GetComponent<FieldOfView>();
        eAnimator = GetComponent<Animator>();
        TargetTransform = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        hearing = GetComponent<hearing>();
    }

    private void Update()
    {
        agent.acceleration = 999;
        hearing.Alert();
        if(isPlaying(eAnimator,"Hurt Blend Tree"))
        {
            
            agent.velocity = Vector3.zero;
        }
        if(health.health <= 0)
        {
            this.enabled = false;
        }
        if (fovScript.canSeePlayer == true && !isPlaying(eAnimator, "Hurt Blend Tree"))
        {
            fovScript.angle = 360f;
            ChaseAfterPlayer();
        }

        if (Vector3.Distance(transform.position, TargetTransform.position) <= maximumDistance && fovScript.canSeePlayer == true && attacked == false && isPlaying(eAnimator, "Hurt Blend Tree")) 
        {
            FacingPlayer();
            AttackPlayerPose();
            //eAnimator.SetBool("isAttacking", true);
        }
        else
        {
            eAnimator.SetBool("isAttacking", false);
            agent.isStopped = false;
        }

        //enemy activated if player get too close
        if (Vector3.Distance(transform.position, TargetTransform.position) < minimumDistance)
        {
            fovScript.angle = 360f;
        }

        if(isPlaying(eAnimator, "AttackingBlendTree"))
        {
            agent.velocity = Vector3.zero;
        }

        Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
    }
    //Note bcuz 4 some reason I get confused by this: minimumDistance < currentDistance < maximumDistance

    //ChasingScript: If distance from this bot to player is greater than maximumDistance, then chase after the Player
    void ChaseAfterPlayer()
    {
        if(!isPlaying(eAnimator, "AttackingBlendTree"))
        {
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

    //ReatreatScript: If distance from this bot to player is smaller than the minimum distance, start retreating
    void ReatreatFromPlayer()
    {
        if (!isPlaying(eAnimator, "AttackingBlendTree"))
        {
            if (Vector3.Distance(transform.position, TargetTransform.position) < minimumDistance)
            {
                eAnimator.SetBool("isAttacking", false);
                fovScript.canSeePlayer = true;
                // transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, -RunningSpeed * Time.deltaTime);

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
        eAnimator.SetBool("isAttacking", true);
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        agent.acceleration = 0;
        agent.speed = 0;
        FacingPlayer();
        agent.isStopped = true;
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
            if (target = null)
            {
                ChaseAfterPlayer();
            }
        }
    }

    void RandomMovement()
    {
        eAnimator.SetBool("isAttacking", false);
        agent.SetDestination(getpoint.GetRandomPoint(transform, radius));
        /* eAnimator.SetBool("isAttacking", false);
         //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
         movementDirection = new Vector3(Random.Range(-1f, 1), 0, Random.Range(-1f, 1));
         movementPerSecond = movementDirection * characterVelocity;
         transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime),transform.position.y, transform.position.z + (movementPerSecond.z * Time.deltaTime));
         attacked = false;*/
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

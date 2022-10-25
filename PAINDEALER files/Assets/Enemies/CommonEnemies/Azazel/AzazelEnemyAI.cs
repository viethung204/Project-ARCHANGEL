using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class AzazelEnemyAI : MonoBehaviour
{
    public float agentSpeed;
    private Transform TargetTransform;
    public float RotationSpeed = 8;
    public float meleeDistance;
    public float rangeDistance;
    public float chaseDistance;
    public float closeDistance;
    NavMeshAgent agent;
    public float meleeDamage = 5;
    public float range = 500f;

    FieldOfView fovScript;
    Rigidbody rb;

    Animator eAnimator;
    Health health;

    hearing hearing;
    Transform thisGuy;

    int animLayer = 0;
    public bool seen = false;

    // Update is called once per frame
    void Start()
    {
        //agent.updateRotation = false;
        rb = gameObject.GetComponent<Rigidbody>();
        fovScript = GetComponent<FieldOfView>();
        eAnimator = GetComponent<Animator>();
        TargetTransform = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        hearing = gameObject.GetComponent<hearing>();
    }
    private void Update()
    {
        agent.speed = agentSpeed;
        hearing.Alert();


        if (fovScript.canSeePlayer == true)
        {
            seen = true;
            fovScript.angle = 360f;
            ChaseAfterPlayer();
        }
        if (seen == true && fovScript.canSeePlayer == false)
        {
            ChaseAfterPlayer();
        }
        //enemy activated if player get too close
        if (Vector3.Distance(transform.position, TargetTransform.position) < closeDistance)
        {
            fovScript.angle = 360f;
        }

        //melee-ing
        if (Vector3.Distance(transform.position, TargetTransform.position) <= meleeDistance)
        {
            eAnimator.SetBool("isRange", false);
            FacingPlayer();
            if (Vector3.Distance(transform.position, TargetTransform.position) <= 2f)
            {
                MeleeAttackPlayerPose();
            }
            if(Vector3.Distance(transform.position, TargetTransform.position) > 2f)
            {
                eAnimator.SetBool("isMelee", false);
            }
        }

        //range attack
        if (Vector3.Distance(transform.position, TargetTransform.position) <= rangeDistance && Vector3.Distance(transform.position, TargetTransform.position) > meleeDistance)
        {
            eAnimator.SetBool("isMelee", false);
            FacingPlayer();
            RangeAttackPlayerPose();
        }

        if(Vector3.Distance(transform.position, TargetTransform.position) > rangeDistance)
        {
            eAnimator.SetBool("isMelee", false);
            eAnimator.SetBool("isRange", false);
            ChaseAfterPlayer();
        }

        if (isPlaying(eAnimator,"Hurt Blend Tree") || isPlaying(eAnimator, "Melee Blend Tree") || isPlaying(eAnimator, "Range Blend Tree"))
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }

        if(health.health <= 0)
        {
            this.enabled = false;
        }


       
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
        
    }
    //Note bcuz 4 some reason I get confused by this: minimumDistance < currentDistance < maximumDistance

    //ChasingScript: If distance from this bot to player is greater than maximumDistance, then chase after the Player
    void ChaseAfterPlayer()
    {
        if(!isPlaying(eAnimator, "Melee Blend Tree") || !isPlaying(eAnimator, "Range Blend Tree"))
        {
            agent.isStopped = false;
            if (Vector3.Distance(transform.position, TargetTransform.position) < chaseDistance)
            {
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

    void MeleeAttackPlayerPose()
    {
        agent.isStopped = true;
        eAnimator.SetBool("isRange", false);
        eAnimator.SetBool("isMelee", true);
        FacingPlayer();
    }

    void RangeAttackPlayerPose()
    {
        agent.isStopped = true;
        eAnimator.SetBool("isMelee", false);
        eAnimator.SetBool("isRange", true);
        FacingPlayer();
    }

    void MeleeAttackPlayer()
    {
        RaycastHit Hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out Hit, range))
        {
            playerHealth target = Hit.transform.GetComponent<playerHealth>();
            if (target != null)
            {
                target.Health -= meleeDamage;
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

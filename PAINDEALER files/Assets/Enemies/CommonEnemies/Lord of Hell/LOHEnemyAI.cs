using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class LOHEnemyAI : MonoBehaviour
{
    public float agentSpeed;
    private Transform TargetTransform;
    public float RotationSpeed = 8;
    public float rangeDistance;
    public float chaseDistance;
    public float detectDistance;
    public float closeDistance;
    NavMeshAgent agent;

    FieldOfView fovScript;
    Rigidbody rb;

    public GameObject LOHprojectile;
    public GameObject SpawnLocation;
    public float throwForce = 20;

    Animator eAnimator;
    Health health;

    hearing hearing;

    int animLayer = 0;

    float time = 0;
    public bool seen = false;

    // Update is called once per frame
    void Start()
    {
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
        
        /*if (fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) < chaseDistance)
        {
            fovScript.angle = 360f;
        }*/

        if(fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) <= chaseDistance && Vector3.Distance(transform.position, TargetTransform.position) > closeDistance)
        {
            fovScript.angle = 360f;
            FacingPlayer();
            time += Time.deltaTime;
            if (time < 2f && time >= 1.018f)
            {
                agent.isStopped = false;
                eAnimator.SetBool("isAttacking", false);
                ChaseAfterPlayer();
            }
            if (time >= 2f)
            {
                agent.isStopped = true;
                AttackPlayerPose();
                time = 0;
            }  
        }
        else
        {
            time = 0;
        }

        if(fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) <= closeDistance)
        {
            FacingPlayer();
            AttackPlayerPose();
        }

        //enemy activated if player get too close
        if (Vector3.Distance(transform.position, TargetTransform.position) < detectDistance)
        {
            fovScript.angle = 360f;
        }

        if (fovScript.canSeePlayer == true)
        {
            
            seen = true;
            fovScript.angle = 360f;
        }

        if (seen == true && fovScript.canSeePlayer == false)
        {
            ChaseAfterPlayer();
        }

        if (health.health <= 0)
        {
            this.enabled = false;
        }

        if (isPlaying(eAnimator, "Hurt Blend Tree") || isPlaying(eAnimator, "Atk Blend Tree"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

        Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
        
    }
    //Note bcuz 4 some reason I get confused by this: minimumDistance < currentDistance < maximumDistance

    //ChasingScript: If distance from this bot to player is greater than maximumDistance, then chase after the Player
    void ChaseAfterPlayer()
    {
        
        if (!isPlaying(eAnimator, "Atk Blend Tree") && !isPlaying(eAnimator, "Hurt Blend Tree"))
        {
            agent.isStopped = false;
            if (Vector3.Distance(transform.position, TargetTransform.position) < chaseDistance)
            {
                FacingPlayer();
                agent.SetDestination(TargetTransform.position);
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
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        eAnimator.SetBool("isAttacking", true);
        FacingPlayer();
    }

    void ProjectileAttack()
    {
        //Create a new gameObject out of the newly spawn projectile
        GameObject grenade = Instantiate(LOHprojectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

        //get its rigidbody
        Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

        //calculate force 
        Vector3 force = transform.forward * throwForce;

        //apply the force
        projectileRb.AddForce(force, ForceMode.Impulse);
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

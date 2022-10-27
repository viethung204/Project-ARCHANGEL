using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class HierophantEnemyAI : MonoBehaviour
{
    
    public float agentSpeed;
    private Transform TargetTransform;
    public float RotationSpeed = 8;
    public float atk1Distance;
    public float atk2Distance;
    public float chaseDistance;
    public float detectDistance;
    public float closeDistance;
    NavMeshAgent agent;

    public GameObject H1projectile;
    public GameObject H2projectile;
    public GameObject HSpawnLocation;
    public float throwForce1;
    public float throwForce2;

    FieldOfView fovScript;
    Rigidbody rb;

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
        
        if (fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) < chaseDistance && Vector3.Distance(transform.position, TargetTransform.position) > atk2Distance)
        {
            
            fovScript.angle = 360f;
            ChaseAfterPlayer();
        }

        //attack1
        if(fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) <= atk1Distance && Vector3.Distance(transform.position, TargetTransform.position) > closeDistance)
        {
            eAnimator.SetBool("isAttacking2", false);
          
            time += Time.deltaTime;
            if (time < 1.201f)
            {
                Attack1PlayerPose();
            }
            if (time < 4 && time >= 1.201f)
            {
                eAnimator.SetBool("isAttacking1", false);
                ChaseAfterPlayer();
            }
            if (time >= 4)
            {
                time = 0;
            }
        }
        else
        {
            time = 0;
        }

        //attack2
        if (fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) <= atk2Distance && Vector3.Distance(transform.position, TargetTransform.position) > atk1Distance && Vector3.Distance(transform.position, TargetTransform.position) < chaseDistance)
        {
            eAnimator.SetBool("isAttacking1", false);
            
            time += Time.deltaTime;
            if(time < 2.351f)
            {
                Attack2PlayerPose();
            }
            if (time < 5 && time >= 2.351f)
            {
                eAnimator.SetBool("isAttacking2", false);
                ChaseAfterPlayer();
            }
            if (time >= 5)
            {
                
                time = 0;
            }
        }
        else
        {
            time = 0;
        }

        if (fovScript.canSeePlayer == true && Vector3.Distance(transform.position, TargetTransform.position) <= closeDistance)
        {
            
            FacingPlayer();
            Attack1PlayerPose();   
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

        if (isPlaying(eAnimator, "Hurt Blend Tree") || isPlaying(eAnimator, "Atk Blend Tree") || isPlaying(eAnimator, "Atk2 Blend Tree"))
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
        eAnimator.SetBool("isAttacking2", false);
        eAnimator.SetBool("isAttacking1", false);
        if (!isPlaying(eAnimator, "Atk Blend Tree") && !isPlaying(eAnimator, "Hurt Blend Tree") && !isPlaying(eAnimator, "Atk2 Blend Tree"))
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

    void Attack1PlayerPose()
    {
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        eAnimator.SetBool("isAttacking1", true);
        FacingPlayer();
    }

    void Attack2PlayerPose()
    {
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        eAnimator.SetBool("isAttacking2", true);
        FacingPlayer();
    }

    void ProjectileAttack1()
    {
        //Create a new gameObject out of the newly spawn projectile
        GameObject grenade = Instantiate(H1projectile, HSpawnLocation.transform.position, HSpawnLocation.transform.rotation);

        //get its rigidbody
        Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

        //calculate force 
        Vector3 force = HSpawnLocation.transform.forward * throwForce1;

        //apply the force
        projectileRb.AddForce(force, ForceMode.Impulse);
    }

    void ProjectileAttack2()
    {
        //Create a new gameObject out of the newly spawn projectile
        GameObject grenade = Instantiate(H2projectile, HSpawnLocation.transform.position, HSpawnLocation.transform.rotation);

        //get its rigidbody
        Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

        //calculate force 
        Vector3 force = HSpawnLocation.transform.forward * throwForce2;

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

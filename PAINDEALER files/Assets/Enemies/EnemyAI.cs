using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public float RunningSpeed;
    public Transform TargetTransform;
    public float RotationSpeed;
    public float minimumDistance;
    public float maximumDistance;

    // Update is called once per frame
    void Update()
    {
        
    }

    //Note bcuz 4 some reason I get confused by this: minimumDistance < currentDistance < maximumDistance

    //ChasingScript: If distance from this bot to player is greater than maximumDistance, then chase after the Player
    void ChaseAfterPlayer()
    {
        if (Vector3.Distance(transform.position, TargetTransform.position) > maximumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, RunningSpeed * Time.deltaTime);
            FacingPlayer();
        }
        else
        {
            FacingPlayer();
        }
    }
    
    //ReatreatScript: If distance from this bot to player is smaller than the minimum distance, start retreating
    void ReatreatFromPlayer()
    {
        if (Vector3.Distance(transform.position, TargetTransform.position) < minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, -RunningSpeed * Time.deltaTime);
            FacingPlayer();
        }
        else
        {
            FacingPlayer();
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

    void EnemyFOV()
    {

    }

    void AttackPlayer()
    {

    }
}

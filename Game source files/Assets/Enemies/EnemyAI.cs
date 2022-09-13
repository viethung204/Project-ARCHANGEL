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

    // Update is called once per frame
    void Update()
    {
        //ChasingScript: If distance from this bot to player is greater than minimumDistance, then chase after the Player;
        if(Vector3.Distance(transform.position, TargetTransform.position) > minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, RunningSpeed * Time.deltaTime);
            LookAtPlayer();
        }
        else
        {
            LookAtPlayer();
        }
    }



    //Look at player with lerp to control the rotation speed
    void LookAtPlayer()
    {
        Vector3 relativePos = TargetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime
            * RotationSpeed);
    }
}

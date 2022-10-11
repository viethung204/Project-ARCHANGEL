using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieNDeadScript : MonoBehaviour
{
    GameObject WeaponsHolder;
    Animator playerAnimator;
    SC_FPSController controller;

    private Transform player;
    private Transform RespawnPoint;

    public GameObject dieFilter;

    playerHealth playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("FPSPlayer").GetComponent<SC_FPSController>();
        WeaponsHolder = GameObject.Find("Weapons Holder");
        playerAnimator = gameObject.GetComponent<Animator>();
        RespawnPoint = GameObject.Find("respawnPoint").GetComponent<Transform>();
        player = GameObject.Find("FPSPlayer").GetComponent<Transform>();
        playerhealth = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        controller.canMove = false;
        playerAnimator.SetBool("dead", true);
        WeaponsHolder.SetActive(false);
        StartCoroutine(RespawnDelay());
        Respawn();
        
    }

    void Respawn()
    { 
       
        controller.canMove = true;

        WeaponsHolder.SetActive(true);
        dieFilter.SetActive(false);
    }

    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(5f);
        playerAnimator.SetBool("dead", false);
        player.transform.position = RespawnPoint.transform.position;
        Physics.SyncTransforms();
        playerhealth.Health = 100;
    }
}

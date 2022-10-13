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
    public GameObject UI;

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
        UI = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        UI.SetActive(false);
        controller.canMove = false;
        playerAnimator.SetBool("dead", true);
        WeaponsHolder.SetActive(false);
        StartCoroutine(Respawn());
        
        
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        playerAnimator.SetBool("dead", false);
        playerAnimator.SetBool("live", true);
        player.transform.position = RespawnPoint.transform.position;
        Physics.SyncTransforms();
        playerhealth.Health = 100;
        controller.canMove = true;
        WeaponsHolder.SetActive(true);
        UI.SetActive(true);
    }
}

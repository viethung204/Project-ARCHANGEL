using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenScript : MonoBehaviour
{
    playerHealth health;
    public int deathScreenIndex;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Capsule").GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.Health <= 0)
        {
            StartCoroutine(DeathTransition());
        }
    }

    IEnumerator DeathTransition()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(deathScreenIndex);
    }
}

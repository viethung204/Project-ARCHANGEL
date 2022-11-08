using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadActiveScene : MonoBehaviour
{
    public Animator fadeAnimator;
    public void LoadScene()
    {
        // Loads the last active scene, or loads "Scene1" if no active scene has been saved.
        // Change "Scene1" to the name of your own first scene.
        // SceneManager.LoadScene(ES3.Load("activeScene", defaultValue: "mainMenu"));
        if (ES3.KeyExists("activeScene"))
        {
            fadeAnimator.SetTrigger("fade");
            StartCoroutine(LoadDelay());
        }
    }

    IEnumerator LoadDelay()
    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(ES3.Load("activeScene", defaultValue: "mainMenu"));
    }
}

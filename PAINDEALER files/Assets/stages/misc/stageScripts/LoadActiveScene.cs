using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadActiveScene : MonoBehaviour
{
    public Animator fadeAnimator;
    public TextMeshProUGUI warnText;
    public void LoadScene()
    {
        // Loads the last active scene, or loads "Scene1" if no active scene has been saved.
        // Change "Scene1" to the name of your own first scene.
        // SceneManager.LoadScene(ES3.Load("activeScene", defaultValue: "mainMenu"));
        if (ES3.KeyExists("activeScene") == true)
        {
            StartCoroutine(LoadDelay());
        }
        else
        {
            warnTextManager.textTimer = 0;
            warnText.enabled = true;
            warnText.text = "No save found.";
        }
    }

    IEnumerator LoadDelay()
    {
        fadeAnimator.SetTrigger("fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(ES3.Load("activeScene", defaultValue: "mainMenu"));
    }

    public void DeleteSave()
    {
        if (ES3.KeyExists("activeScene") == true)
        {
            ES3.DeleteKey("activeScene");
            warnTextManager.textTimer = 0;
            warnText.enabled = true;
            warnText.text = "Save deleted.";
        }
        else
        {
            warnTextManager.textTimer = 0;
            warnText.enabled = true;
            warnText.text = "No save found.";
        }
        
    }
}

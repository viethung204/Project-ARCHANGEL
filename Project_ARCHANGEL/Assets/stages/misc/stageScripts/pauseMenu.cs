using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject weaponsHolder;
    public GameObject GHolder;
    public GameObject Capsule;
    public SC_FPSController controller;
    public int LoadingScreenIndex;

    public Animator fadeAnimator;
    public int mainMenuIndexNumber;

    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        weaponsHolder.SetActive(true);
        GHolder.SetActive(true);
        Capsule.SetActive(true);
        controller.enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        weaponsHolder.SetActive(false);
        GHolder.SetActive(false);
        Capsule.SetActive(false);
        controller.enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit2Menu()
    {
        Time.timeScale = 1f;
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(LevelTransition());
        //SceneManager.LoadScene(mainMenuIndexNumber);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(RestartTransition());
    }

    public IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(mainMenuIndexNumber);
    }
    public IEnumerator RestartTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LoadingScreenIndex);
    }
}

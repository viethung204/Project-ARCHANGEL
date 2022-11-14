using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScreenButton : MonoBehaviour
{
    public int NextLevelLoadingScreen;
    public int thisLevelLoadingScreen;
    public int MainMenuIndex;

    Animator fadeAnimator;

    private void Start()
    {
        fadeAnimator = GameObject.Find("CrossfadeThingy").GetComponent<Animator>();
    }
    public void NextLevel()
    {
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(nextLevelTransition());
    }

    public void restartLevel()
    {
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(RestartTransition());
    }

    public void mainMenu()
    {
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(mainMenuTransition());
    }

    public IEnumerator nextLevelTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(NextLevelLoadingScreen);
    }
    public IEnumerator RestartTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(thisLevelLoadingScreen);
    }
    public IEnumerator mainMenuTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(MainMenuIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingScreen : MonoBehaviour
{
    public Animator fadeAnimator;
    public int nextLevel;
    void Start()
    {
        StartCoroutine(FadeAfterDelay(4f));
        StartCoroutine(LoadLevelAfterDelay(5f));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator FadeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        fadeAnimator.SetTrigger("fade");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SearchService;

public class NextLevel : MonoBehaviour
{
    public Animator fadeAnimator;
    public int nextLevelIndexNumber;

    // Update is called once per frame
    public void intoTheGame()
    {
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(LevelTransition());
    }

    public IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevelIndexNumber);
    }
}

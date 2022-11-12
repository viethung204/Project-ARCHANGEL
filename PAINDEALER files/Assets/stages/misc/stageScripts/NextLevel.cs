using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SearchService;

public class NextLevel : MonoBehaviour
{
    public Animator fadeAnimator;
    public int nextLevelIndexNumber;

    public GameObject thisContainer;
    public GameObject confirmContainer;

    // Update is called once per frame
    public void Yes()
    {
        fadeAnimator.SetTrigger("fade");
        StartCoroutine(LevelTransition());
    }

    public IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevelIndexNumber);
    }

    public void Confirmation()
    {
        if (ES3.KeyExists("activeScene") == true)
        {
            thisContainer.SetActive(false);
            confirmContainer.SetActive(true);
        }
        else
        {
            Yes();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalStageManager : MonoBehaviour
{
    public Health HierophantHealth;
    public Animator fadeAnimator;
    public int stage4WonScreen;
    public StageKillCount killCount;
    public timeCounting timeCounter;

    private void Update()
    {
        if(HierophantHealth.health <= 0)
        {

            StartCoroutine(Won());
        }
    }

    IEnumerator Won()
    {
        yield return new WaitForSeconds(4f);
        fadeAnimator.SetTrigger("fade");
        killCount.UpdateKillCount();
        timeCounter.UpdateTime();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(stage4WonScreen);
    }
}

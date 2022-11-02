using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youWonButton : MonoBehaviour
{
    public GameObject finalButton;
    public int secondsWait;

    private void Update()
    {
        StartCoroutine(ButtonDelay());
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(secondsWait);
        finalButton.active = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageKillCount : MonoBehaviour
{
    public static int KillCount;

    private void Start()
    {
        KillCount = 0;
    }

    private void Update()
    {
        KillCount = GameObject.FindGameObjectsWithTag("died").Length;
    }
    public void UpdateKillCount()
    {

        PlayerPrefs.SetInt("killCount", KillCount);
    }
}

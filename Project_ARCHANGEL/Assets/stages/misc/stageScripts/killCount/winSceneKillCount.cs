using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winSceneKillCount : MonoBehaviour
{
    int winKillCount;
    public TextMeshProUGUI KillCount;

    private void Start()
    {
        winKillCount = PlayerPrefs.GetInt("killCount");
        KillCount.text = winKillCount.ToString();
    }

    
}

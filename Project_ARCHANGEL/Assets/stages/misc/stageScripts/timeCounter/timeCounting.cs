using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeCounting : MonoBehaviour
{
    public float Timer;
    
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    private void Update()
    {
        Timer = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    public void UpdateTime()
    {
        PlayerPrefs.SetFloat("TimerPrefs", Timer);
    }
}

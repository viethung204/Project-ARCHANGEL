using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winScreenManager : MonoBehaviour
{
    public Sprite winBG01;
    public Sprite winBG02;
    public Sprite winBG03;
    public Sprite winBG04;

    public int dice;

    // Start is called before the first frame update
    void Start()
    {
        dice = Random.Range(1, 5);
        if(dice == 1)
        {
            gameObject.GetComponent<Image>().sprite = winBG01;
        }
        if (dice == 2)
        {
            gameObject.GetComponent<Image>().sprite = winBG02;
        }
        if (dice == 3)
        {
            gameObject.GetComponent<Image>().sprite = winBG03;
        }
        if (dice == 4)
        {
            gameObject.GetComponent<Image>().sprite = winBG04;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundManager : MonoBehaviour
{
    public Sprite mainBG01;
    public Sprite mainBG02;
    public Sprite mainBG03;
    public Sprite mainBG04;
    public Sprite mainBG05;
    public Sprite mainBG06;
    public Sprite mainBG07;

    public int dice;

    // Start is called before the first frame update
    void Start()
    {
        dice = Random.Range(1, 8);
        if(dice == 1)
        {
            gameObject.GetComponent<Image>().sprite = mainBG01;
        }
        if (dice == 2)
        {
            gameObject.GetComponent<Image>().sprite = mainBG02;
        }
        if (dice == 3)
        {
            gameObject.GetComponent<Image>().sprite = mainBG03;
        }
        if (dice == 4)
        {
            gameObject.GetComponent<Image>().sprite = mainBG04;
        }
        if (dice == 5)
        {
            gameObject.GetComponent<Image>().sprite = mainBG05;
        }
        if (dice == 6)
        {
            gameObject.GetComponent<Image>().sprite = mainBG06;
        }
        if (dice == 7)
        {
            gameObject.GetComponent<Image>().sprite = mainBG07;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

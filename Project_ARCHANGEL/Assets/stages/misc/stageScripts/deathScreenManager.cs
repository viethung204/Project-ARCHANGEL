using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathScreenManager : MonoBehaviour
{
    public Sprite deathBG01;
    public Sprite deathBG02;
    public Sprite deathBG03;
    public Sprite deathBG04;
    public Sprite deathBG05;
    public Sprite deathBG06;

    public int dice;

    // Start is called before the first frame update
    void Start()
    {
        dice = Random.Range(1, 7);
        if(dice == 1)
        {
            gameObject.GetComponent<Image>().sprite = deathBG01;
        }
        if (dice == 2)
        {
            gameObject.GetComponent<Image>().sprite = deathBG02;
        }
        if (dice == 3)
        {
            gameObject.GetComponent<Image>().sprite = deathBG03;
        }
        if (dice == 4)
        {
            gameObject.GetComponent<Image>().sprite = deathBG04;
        }
        if (dice == 5)
        {
            gameObject.GetComponent<Image>().sprite = deathBG05;
        }
        if (dice == 6)
        {
            gameObject.GetComponent<Image>().sprite = deathBG06;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

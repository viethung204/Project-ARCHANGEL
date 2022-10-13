using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI
;
public class WeaponsNotiController : MonoBehaviour
{
    private Text WeaponsNoti;
    public float textTimer = 0; // timer, starts when text first appear
    public int textTime = 3; //the amount of time text stay on b4 off;


    // Start is called before the first frame update
    void Start()
    {
        WeaponsNoti = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (textTimer > textTime)
        {
            WeaponsNoti.enabled = false;
        }
        if (WeaponsNoti.enabled == true)
        {
            textTimer += Time.deltaTime;  
        }
        if(WeaponsNoti.enabled == false)
        {
            textTimer = 0;
            textTime = 3;
        }
    }

    public IEnumerator fuckingkillme()
{
    yield return new WaitForSeconds(3f);
    WeaponsNoti.enabled = false;
}

}

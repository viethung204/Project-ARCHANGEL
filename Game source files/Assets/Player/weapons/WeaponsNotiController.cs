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

    // Start is called before the first frame update
    void Start()
    {
        WeaponsNoti = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if(WeaponsNoti.enabled == true)
        {
            StartCoroutine(fuckingkillme());
        }
    }

    public IEnumerator fuckingkillme()
{
    yield return new WaitForSeconds(3f);
    WeaponsNoti.enabled = false;
}

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI
;
public class WeaponsNotiController : MonoBehaviour
{
    public Text WeaponsNoti;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        StartCoroutine(fuckingkillme());

    }

    IEnumerator fuckingkillme()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class CrosshairScript : MonoBehaviour
{
    public Image reticle;


    private void Start()
    {
        reticle.color = new Color(1, 1, 1, 0.75f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f) && hit.transform.gameObject.CompareTag("Enemy"))
        {
                reticle.color = new Color(1, 0.92f, 0.016f, 1f);   
        }
        else
        {
            reticle.color = new Color(1, 1, 1, 0.75f);
        }
    }
}

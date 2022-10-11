using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float Health = 100f;
    public float Armor = 100f;
    Text armorText;
    Text healthText;
    public Animator playerAnimator;
    Image HealthIndicator;
    Image ArmorIndicator;
    public bool BioSuit = false;

    DieNDeadScript dieScript;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("healthText").GetComponent<Text>();
        armorText = GameObject.Find("ArmorText").GetComponent<Text>();
        ArmorIndicator = GameObject.Find("ArmorIndicator").GetComponent<Image>();
        HealthIndicator = GameObject.Find("healthIndicator").GetComponent<Image>();
        dieScript = gameObject.GetComponent<DieNDeadScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (BioSuit == true)
        {
            StartCoroutine(Dissolve());
        }

        healthText.text = Health.ToString();
        HealthIndicator.fillAmount = Health/100;
        armorText.text = Armor.ToString();
        ArmorIndicator.fillAmount = Armor / 100;
        if (Health <= 0)
        {
            Health = 0;
            dieScript.Dead();
        }
        if(Health > 100)
        {
            Health = 100;
            
        }
        if(Health <= 50)
        {
            healthText.color = Color.yellow;
        }
        if(Health <= 25)
        {
            healthText.color = Color.red;
        }
        if (Health > 50)
        {
            healthText.color = Color.white;
        }
        
    }

    IEnumerator Dissolve()
    {
        yield return new WaitForSeconds(30f);
        BioSuit = false;
    }
}

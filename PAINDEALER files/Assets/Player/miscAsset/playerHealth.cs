using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float Health = 100f;
    private float m_Health = 100f;
    public static float Armor;
    private float damageTaken;
    Text armorText;
    Text healthText;
    public Animator playerAnimator;
    Image HealthIndicator;
    Image ArmorIndicator;
    public static bool BioSuit = false;

    public static bool powerUp = false;
    public Image powerUpFilter;
    DieNDeadScript dieScript;

    GameObject hitFilter;


    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("healthText").GetComponent<Text>();
        armorText = GameObject.Find("ArmorText").GetComponent<Text>();
        ArmorIndicator = GameObject.Find("ArmorIndicator").GetComponent<Image>();
        HealthIndicator = GameObject.Find("healthIndicator").GetComponent<Image>();
        dieScript = gameObject.GetComponent<DieNDeadScript>();
        hitFilter = GameObject.Find("hitFilter");
    }

    // Update is called once per frame
    void Update()
    {
        if(powerUp == true)
        {
            powerUpFilter.enabled = true;
            Health = 100;
            Shredder.damage = 20f;
            RevolverScript.damage = 40f;
            PumpShotgun.damage = 40f;
            ShotgunScript.damage = 40f;
            Fist.damage = 12f;
        }
        else
        {
            powerUpFilter.enabled = false;
            Shredder.damage = 5f;
            RevolverScript.damage = 10f;
            PumpShotgun.damage = 10f;
            ShotgunScript.damage = 10f;
            Fist.damage = 3f;
        }

        if(Armor <= 0)
        {
            Armor = 0;
        }
        if(Armor >= 100)
        {
            Armor = 100;
        }

        if (Health < m_Health)
        {
            GotHurt();
            if(Armor > 0)
            {
                damageTaken = m_Health - Health;
                Health = m_Health - (damageTaken * 2/3);
                Armor = Armor - (damageTaken * 1/3);
                m_Health = Health;
            }
            else
            {
                m_Health = Health;
            }
        }
        else if(Health > m_Health)
        {

           m_Health = Health;
        }

        if (BioSuit == true)
        {
            StartCoroutine(Dissolve());
        }
        if(powerUp == true)
        {
            StartCoroutine(PowerDown());
        }
        healthText.text = Mathf.Round(Health).ToString();
        HealthIndicator.fillAmount = Health/100;
        armorText.text = Mathf.Round(Armor).ToString();
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

        //have to set a cap because if you have like, say 90 health, and you picked up a health pack that add 30, then Health would be 130 -> m_Health = 130 then Health go down to 100 while
        //m_Health is still 130, which then trigger the Health < m_Health event before m_Health go down to 100
        if (m_Health > 100)
        {
            m_Health = 100;

        }
        if (Health <= 50)
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

    IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(15f);
        powerUp = false;
    }

    IEnumerator Dissolve()
    {
        yield return new WaitForSeconds(15f);
        BioSuit = false;
    }

    void GotHurt()
    {
        var color = hitFilter.GetComponent<Image>().color;
        color.a = 0.6f;
        hitFilter.GetComponent<Image>().color = color;
    }
}

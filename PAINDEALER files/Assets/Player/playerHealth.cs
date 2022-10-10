using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float Health = 100f;
    //float Armor = 100;
    //Text armorText;
    Text healthText;
    Animator playerAnimator;
    Image HealthIndicator;
    Image ArmorIndicator;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("healthText").GetComponent<Text>();
        playerAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        HealthIndicator = GameObject.Find("healthIndicator").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Health.ToString();
        HealthIndicator.fillAmount = Health/100;
        if (Health < 0)
        {
            Health = 0;
            Die();
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
        
    }

    void Die()
    {
        playerAnimator.SetBool("dead", true);
    }
}

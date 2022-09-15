using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public int selectedWeapon = 0;

    void Start()
    {
        //first when boot up, call SelectWeapon method so that fist is the 1st weapon
        SelectWeapon();
    }

    void Update()
    {
        //basically, what is do is have a number that represent the weapon b4 changing 
        //keep in mind that c sharp is order sensitive
        //then throw in some script that change weapon and the selectedWeapon variable based on keys
        //finally compare between the PSW variable and the SW variable, if it's not the same, call SelectWeapon method to change the weapon based on the (new) current SW variable

        int previousSelectedWeapons = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if(previousSelectedWeapons != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    //if this seems confusing, childCount does not work from 0, that's why childCount need - 1
    //selectedWeapon = array = childCount - 1 = 0

    //change weapon based on array
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        } 
    }
}

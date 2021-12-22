using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPush : MonoBehaviour
{
    int abilityCooldown;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 0;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")) //key for ability activate
        {
            isActive = true;
            abilityCooldown = 12;
            //ability goes here
        }
        StartCoroutine(Cooldown());
    }

     IEnumerator Cooldown()
    {
        while(abilityCooldown>0)
        {
            abilityCooldown--;
            yield return new WaitForSeconds(1);
        }
    }

}

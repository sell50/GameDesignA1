using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFreeze : MonoBehaviour
{
    int abilityCooldown;
    bool isActive;
    Rigidbody Enemy;
    Vector3 Yaxis;
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 0;
        isActive = false;
        Enemy = GetComponent<Rigidbody>();
        //Set up vector for moving the Rigidbody in the y axis
        Yaxis = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")) //key for ability activate
        {
            isActive = true;
            abilityCooldown = 13;
            //ability goes here
            Enemy.constraints = RigidbodyConstraints.FreezePosition;
        }

        //Press the up arrow key to move positively in the y axis if the constraints are removed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //If the constraints are removed, the Rigidbody moves along the y axis
            //If the constraints are there, no movement occurs
            Enemy.velocity = Yaxis;
        }

        //Press the down arrow key to move negatively in the y axis if the constraints are removed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Enemy.velocity = -Yaxis;
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

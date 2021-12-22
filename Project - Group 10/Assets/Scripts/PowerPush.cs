using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPush : MonoBehaviour
{
    int abilityCooldown;
    bool isActive;
    float force = 3;
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

    void OnCollisionEnter(Collision other)
    {
        float force = 3;
        if (other.gameObject.tag == "enemy")
        {
            
            Vector3 dir = other.contacts[0].point - transform.position;
            
            dir = -dir.normalized;
    
            GetComponent<Rigidbody>().AddForce(dir*force);
        }
    }

}

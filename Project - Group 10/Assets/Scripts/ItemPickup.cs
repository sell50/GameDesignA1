using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float speed;
    public int ammo;
    public int health;
    public int shield;
    public int advantage;
    public int characterSpeed;
    public int jump;
    public bool special = true;
    public int percent;
    public int cooldown;
    public bool cooldownIsOff = false;
    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, other.transform.position) <= 0.5)
        {
            if(gameObject.tag == "ammo") //ammo pickup
                ammo+=10;
            if(gameObject.tag == "health") //health pickup
                health+=15;
            if(gameObject.tag == "shield") //shield pickup
                shield+=25;
            if(gameObject.tag == "advantage") //advantage pickup
                characterSpeed*=2;
                jump*=2;

            if(gameObject.tag == "chaos") //chaos pickup
            {
                percent = Random.Range(1,100);
                if(0<percent && percent<=30)
                {
                    cooldown = 0;
                    cooldownIsOff = true;
                }
                else
                {
                    characterSpeed/=2;
                    jump/=2;
                    //cant move?
                    health-=3;
                    //knocked down?
                }
            }
            Destroy(gameObject);
        }
    }

    public int GetAmmo()
    {
        return ammo;
    }
}

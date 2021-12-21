using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float speed;
    public int ammo;
    public int health;
    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, other.transform.position) <= 0.5)
        {
            if(gameObject.tag == "ammo")
                ammo++;
            if(gameObject.tag == "health")
                health++;
            Destroy(gameObject);
        }
    }

    
}

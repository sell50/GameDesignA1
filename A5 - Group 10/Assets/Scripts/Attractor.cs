using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float speed;
    public int coins;
    private void OnTriggerStay(Collider other)
    {
        coins = 0;
        if (other.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, other.transform.position) <= 0.5)
        {
            coins++;
            Destroy(gameObject);
        }
    }

    
}

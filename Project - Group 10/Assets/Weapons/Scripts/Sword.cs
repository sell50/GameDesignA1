using System.Collections;
using System.Collections.Generic;
using Characters.Scripts;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))        //choose appropriately
        {
            //reduce character health 7-10 damage
            other.gameObject.GetComponent<PlayerManager>().TakeDamage(Random.Range(7, 10));
        }
    }
}

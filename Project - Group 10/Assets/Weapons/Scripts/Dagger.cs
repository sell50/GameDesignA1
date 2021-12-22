using System.Collections;
using System.Collections.Generic;
using Characters.Scripts;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))        //choose appropriately
        {
            //reduce character health 4-7 damage
            other.gameObject.GetComponent<PlayerManager>().TakeDamage(Random.Range(4, 7));
        }
    }
}

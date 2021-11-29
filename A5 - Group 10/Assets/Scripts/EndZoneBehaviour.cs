using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneBehaviour : MonoBehaviour
{
    public bool endReached;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endReached = true;
        }
    }
    
    //TODO: Figure out how to generate new level upon reaching end zone
}

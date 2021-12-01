using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneBehaviour : MonoBehaviour
{
    public bool endReached;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(endReached);
        //if (!other.gameObject.CompareTag("Player")) return;
        endReached = true;
        Debug.Log(endReached);
    }
    
    //TODO: Figure out how to generate new level upon reaching end zone
    //Problem is, procedural navmesh system detects the trigger collider and puts the navmesh on top - they're never really triggering
}

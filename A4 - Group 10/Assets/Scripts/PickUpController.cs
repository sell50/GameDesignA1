using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Weapon gunScript;
    public Rigidbody rb;
    public Collider coll;
    public Transform player, gunContainer;

    public float pickupRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude < pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
    }

    private void PickUp()
    {
        
    }

    private void Drop()
    {
        
    }
}

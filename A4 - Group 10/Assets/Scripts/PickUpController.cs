using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Weapon gunScript;
    public Rigidbody rb;
    public Collider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickupRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude < pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        rb.isKinematic = true;
        coll.isTrigger = true;

        gunScript.enabled = true;
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;
        
        transform.SetParent(null);
        
        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);

        gunScript.enabled = false;
    }
}

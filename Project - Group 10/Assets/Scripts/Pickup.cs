using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        transform.position = other.gameObject.transform.Find("Destination").transform.position;
        transform.parent = GameObject.Find("Destination").transform;
    }

    private void OnMouseUp()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}

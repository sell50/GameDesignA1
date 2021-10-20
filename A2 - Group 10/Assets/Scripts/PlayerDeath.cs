using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Vector3 reset;
    //public Tr controller;

    void Start()
    {
        reset = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathFloor"))
        {
            transform.gameObject.SetActive(false);
            transform.position = reset;
            transform.gameObject.SetActive(true);
        }

    }

}





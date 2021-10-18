using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Vector3 reset;
    public CharacterController controller;


    void Start()
    {
        reset = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathFloor"))
        {
            controller.enabled = false;
            transform.position = reset;
            controller.enabled = true;
        }

    }

}





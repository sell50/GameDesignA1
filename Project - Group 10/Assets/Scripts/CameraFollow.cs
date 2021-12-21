using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [HideInInspector]public Transform playerTransform;
    public int depth = -20;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
        }
    }


    public void SetTarget(Transform target)
    {
        playerTransform = target;
    }
}

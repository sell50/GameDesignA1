using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDeathZone : MonoBehaviour
{
    public Vector3 offset;
    float speed = 1;
    
    
    void Start()
    {
        offset = transform.position;
    }


    void Update()
    {

       
        if (transform.position.y >= offset.y + 2)
        {
            speed = -1.0f;
        }
        else if (transform.position.y <= offset.y - 3) 
        {
            speed = 1.0f;
        }

        transform.Translate(0, Time.deltaTime * speed, 0f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIt : MonoBehaviour
{
   
    float sum = 1.0f;
    void Update()
    {
        if (transform.position.x >= 3) sum = -1.0f;
        else if (transform.position.x <= -3) sum = 1.0f;

        transform.Translate(Time.deltaTime*sum, 0f, 0f);

    }
}

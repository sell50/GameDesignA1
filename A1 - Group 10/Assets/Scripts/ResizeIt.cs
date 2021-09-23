using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeIt : MonoBehaviour
{
    private Vector3 scaleChange;
    private void Awake()
    {
        scaleChange = new Vector3(1f, 1f, 1f);
    }
    
    void Update()
    {
        transform.localScale += scaleChange * Time.deltaTime;

        if (transform.localScale.x >= 4f || transform.localScale.x <= 1f)
        {
            scaleChange = -scaleChange;
        }
    }
}

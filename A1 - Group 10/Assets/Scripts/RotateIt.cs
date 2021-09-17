using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            Time.deltaTime * 30f, 
            Time.deltaTime * 60f, 
            Time.deltaTime * 90f
            );
    }
}

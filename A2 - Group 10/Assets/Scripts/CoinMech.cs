using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMech : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * 30f,
            Time.deltaTime * 15f,
            Time.deltaTime * 45f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}

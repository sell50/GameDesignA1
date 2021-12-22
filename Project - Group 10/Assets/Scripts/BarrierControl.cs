using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    private int i = 0;
    [SerializeField] private GameObject b1;
    [SerializeField] private GameObject b2;
    [SerializeField] private GameObject b3;
    [SerializeField] private GameObject b4;
    [SerializeField] private GameObject b5;
    [SerializeField] private GameObject b6;
    [SerializeField] private GameObject b7;
    [SerializeField] private GameObject b8;

    void Start()
    {
        InvokeRepeating("MoveBarrier", 1.0f, 30.0f);
    }

    // Update is called once per frame
    void MoveBarrier()
    {
        if (i == 0)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);

            b5.SetActive(false);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);

            i = 1;
        }
        else
        {
            b1.SetActive(false);
            b2.SetActive(false);
            b3.SetActive(false);
            b4.SetActive(false);

            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);

            i = 0;
        }

    }
}
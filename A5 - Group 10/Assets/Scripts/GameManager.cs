using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    GameObject endScreen;
    bool endScreenActive = false;
    void Start()
    {
        endScreen = GameObject.Find("EndScreen");
        endScreen.SetActive(endScreenActive);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("This will probably work");
            endScreen.SetActive(!endScreenActive);
            endScreenActive = !endScreenActive;
        }
    }
}

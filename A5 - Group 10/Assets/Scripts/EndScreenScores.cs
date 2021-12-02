using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class EndScreenScores : MonoBehaviour
{
    public TMP_Text coinsPU, timeEl, lvlComp;
    float TimeT;

    void Update()
    {
        lvlComp.text = GameObject.Find("LevelGenerator").GetComponent<ProceduralLevelGeneration>().levelsGenerated.ToString();
        coinsPU.text = GameObject.Find("Coin").GetComponent<Attractor>().coins.ToString();

        TimeT += Time.deltaTime;
           
        Debug.Log("TIMER:" + TimeT);
    }
}

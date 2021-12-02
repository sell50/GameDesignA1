using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class EndScreenScores : MonoBehaviour
{
    public TMP_Text keysPU, timeEl, lvlComp;

    void Update()
    {
        lvlComp.text = GameObject.Find("LevelGenerator").GetComponent<ProceduralLevelGeneration>().levelsGenerated.ToString();
    }
}

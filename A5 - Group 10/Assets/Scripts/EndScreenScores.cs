using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class EndScreenScores : MonoBehaviour
{
    public TMP_Text keysPU, timeEl, lvlComp;
    public GameObject levelsComplete;
    public ProceduralLevelGeneration level;
   
    void start()
    {
        levelsComplete = GameObject.Find("LevelGenerator");
        level = levelsComplete.GetComponent<ProceduralLevelGeneration>();
        Debug.Log(1);
    }
}

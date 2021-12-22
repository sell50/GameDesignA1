using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int redTeamScore;
    [HideInInspector] public int blueTeamScore;
    public static GameManager instance;

    public GameObject scoresPanel;
    public TMP_Text redScoreText;
    public TMP_Text blueScoreText; 

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Scripts;
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

    public GameObject firstArena;
    public GameObject secondArena;

    private PlayerSpawner _spawner;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (redTeamScore >= 10 || blueTeamScore >= 10)
        {
            //switch to new arena - respawn all the players there
            
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform redSpawnPoint;
    public Transform blueSpawnPoint;

    private GameObject player;
    private GameObject camera;
    
    [Header("Camera")]
    [Tooltip("How far back the camera should be from the player")]
    public Vector3 offset;

    void Start()
    {
        var playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerClass"]];

        var team = (int) PhotonNetwork.LocalPlayer.CustomProperties["playerTeam"];
        GameObject spawnedPlayer = null;
        
        switch (team)
        {
            case 0: //red team
                spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, redSpawnPoint.position, Quaternion.identity);
                break;
            case 1: //blue team
                spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, blueSpawnPoint.position, Quaternion.identity);
                break;
        }

        if (spawnedPlayer != null)
        {
            player = spawnedPlayer;
            if (Camera.main is { }) camera = Camera.main.gameObject;
            camera.transform.position = player.transform.position; 
        }
        
        
    }

    private void FixedUpdate()
    {
        if (player != null && camera != null)
        {
            camera.transform.position = player.transform.position - offset;
        }
    }
}

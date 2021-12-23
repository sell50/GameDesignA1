using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] firstArenaRedSpawnPoints;
    public Transform[] firstArenaBlueSpawnPoints;
    public Transform[] secondArenaRedSpawnPoints;
    public Transform[] secondArenaBlueSpawnPoints;

    [Header("Camera")]
    [Tooltip("How far back the camera should be from the player")]
    public Vector3 offset;
    
    private GameObject player;
    private GameObject camera;
    private bool switchedArenas = false;

    void Start()
    {
        var spawnedPlayer = Spawn(firstArenaRedSpawnPoints, firstArenaBlueSpawnPoints);

        AttachCamera(spawnedPlayer);
    }

    private void AttachCamera(GameObject spawnedPlayer)
    {
        if (spawnedPlayer != null)
        {
            player = spawnedPlayer;
            if (Camera.main is { }) camera = Camera.main.gameObject;
            camera.transform.position = player.transform.position;
        }
    }

    private GameObject Spawn(Transform[] redSpawnPoints, Transform[] blueSpawnPoints)
    {
        var playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerClass"]];
        var team = (int) PhotonNetwork.LocalPlayer.CustomProperties["playerTeam"];
        GameObject spawnedPlayer = null;

        switch (team)
        {
            case 0: //red team
                var redSpawnPoint = redSpawnPoints[Random.Range(0, redSpawnPoints.Length)];
                spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, redSpawnPoint.position, Quaternion.identity);
                break;
            case 1: //blue team
                var blueSpawnPoint = blueSpawnPoints[Random.Range(0, blueSpawnPoints.Length)];
                spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, blueSpawnPoint.position, Quaternion.identity);
                break;
        }

        return spawnedPlayer;
    }

    private void FixedUpdate()
    {
        if (player != null && camera != null)
        {
            camera.transform.position = player.transform.position - offset;
        }
    }

    public void Respawn()
    {
        GameObject spawnedPlayer;
        if (!switchedArenas)
        { 
            spawnedPlayer = Spawn(firstArenaRedSpawnPoints, firstArenaBlueSpawnPoints);
        }
        else
        {
            spawnedPlayer = Spawn(secondArenaRedSpawnPoints, secondArenaBlueSpawnPoints);
        }
        
        AttachCamera(spawnedPlayer);
    }
    
    //
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform redSpawnPoint;
    public Transform blueSpawnPoint;
    
    // TODO: Adapt Spawn so each team spawns on their side
    void Start()
    {
        var playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerClass"]];

        var team = (int) PhotonNetwork.LocalPlayer.CustomProperties["playerTeam"];
        switch (team)
        {
            case 0: //red team
                PhotonNetwork.Instantiate(playerToSpawn.name, redSpawnPoint.position, Quaternion.identity);
                break;
            case 1: //blue team
                PhotonNetwork.Instantiate(playerToSpawn.name, blueSpawnPoint.position, Quaternion.identity);
                break;
        }
        //PhotonNetwork.Instantiate(playerToSpawn.name, new Vector3(0f, 5f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

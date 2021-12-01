using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ProceduralLevelGeneration : MonoBehaviour
{
    
    [SerializeField] private Transform startRoom;
    [SerializeField] private Transform endRoom;
    [SerializeField] private GameObject levelContainer;
    [SerializeField] private List<Transform> levelPrefabs;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private NavMeshBaker navMeshBaker;
    private GameObject endZone;

    [SerializeField] private int roomCount;

    Vector3 lastRoomExitPoint;
    private GameObject player;

    //private EndZoneBehaviour endZone;
    private bool levelEndReached;

    private void Awake()
    {
        SpawnNewLevel();
    }

    private void Start()
    {
        player = SpawnPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("This is how I refresh");
            StartCoroutine(GenerateNewLevel());
        }
        /*if (endZone.GetComponent<EndZoneBehaviour>().endReached)
        {
            
        }*/
    }

    private void SpawnRoom()
    {
        var chosenRoom = levelPrefabs[Random.Range(0, levelPrefabs.Count)];
        var roomStartPos = chosenRoom.Find("StartPoint").position;
        var spawnPosition = lastRoomExitPoint + chosenRoom.position - roomStartPos;
        Transform lastRoomTransform = SpawnRoom(chosenRoom, spawnPosition, Quaternion.identity);
        lastRoomExitPoint = lastRoomTransform.Find("EndPoint").position;
    }

    private Transform SpawnRoom(Transform roomPrefab, Vector3 spawnPosition, Quaternion rotation)
    {
        var roomTransform = Instantiate(roomPrefab, spawnPosition, rotation);
        roomTransform.SetParent(levelContainer.transform);
        return roomTransform;
    }
    
    private void SpawnNewLevel()
    {
        lastRoomExitPoint = startRoom.Find("EndPoint").position;
        
        
        for (int i = 0; i < roomCount; i++)
        {
            SpawnRoom();
        }

        var endRoomStartPos = endRoom.Find("StartPoint").position;
        var  endRoomSpawnPos = lastRoomExitPoint + endRoom.position - endRoomStartPos;
        SpawnRoom(endRoom, endRoomSpawnPos, Quaternion.Euler(0, 180, 0));
        
        endZone = endRoom.Find("EndZone").gameObject;
        //do a coroutine, to wait a few seconds before the new level starts
    }

    private GameObject SpawnPlayer()
    {
        var playerSpawnPosition = startRoom.Find("PlayerSpawnPoint").position;
         return Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
    }

    IEnumerator GenerateNewLevel()
    {
        Debug.Log("CoroutineReached");
        //destroy old level, place new startRoom 
        foreach (Transform child in levelContainer.transform)
        {
            Destroy(child.gameObject);
        }
        
        player.gameObject.SetActive(false);
        //DestroyImmediate(Player, true);
        
        var newStartRoom = Instantiate(startRoom, new Vector3(0, 0, 0), Quaternion.identity);
        newStartRoom.SetParent(levelContainer.transform);
        startRoom = newStartRoom;
        SpawnNewLevel();
        //TODO: Some problems with baking new navmesh for newly generated level
        navMeshBaker.BakeNavMesh();
        player = SpawnPlayer();
        yield return new WaitForSeconds(1.5f);
    }
    
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralLevelGeneration : MonoBehaviour
{
    
    [SerializeField] private Transform startRoom;
    [SerializeField] private Transform endRoom;
    [SerializeField] private GameObject levelContainer;
    [SerializeField] private List<Transform> levelPrefabs;

    [SerializeField] private int roomCount;

    Vector3 lastRoomExitPoint;

    private EndZoneBehaviour endZone;
    private bool levelEndReached;

    private void Awake()
    {
        SpawnNewLevel();
    }

    private void Update()
    {
        if (endZone.endReached)
        {
            StartCoroutine(GenerateNewLevel());
        }
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

        //int RoomCount = 5;
        for (int i = 0; i < roomCount; i++)
        {
            SpawnRoom();
        }

        var endRoomStartPos = endRoom.Find("StartPoint").position;
        var  endRoomSpawnPos = lastRoomExitPoint + endRoom.position - endRoomStartPos;
        SpawnRoom(endRoom, endRoomSpawnPos, Quaternion.Euler(0, 180, 0));
        endZone = endRoom.Find("EndZone").gameObject.GetComponent<EndZoneBehaviour>();
        //do a coroutine, to wait a few seconds before the new level starts
    }

    IEnumerator GenerateNewLevel()
    {
        Debug.Log("CoroutineReached");
        //destroy old level, place new startRoom 
        foreach (Transform child in levelContainer.transform)
        {
            Destroy(child);
        }

        Instantiate(startRoom, new Vector3(0, 0, 0), Quaternion.identity);
        startRoom.SetParent(levelContainer.transform);
        SpawnNewLevel();
        yield return new WaitForSeconds(1.5f);
    }
    
    
}

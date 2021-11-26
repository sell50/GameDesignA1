using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralLevelGeneration : MonoBehaviour
{
    
    [SerializeField] private Transform startRoom;
    [SerializeField] private Transform endRoom;
    [SerializeField] private List<Transform> levelPrefabs;

    [SerializeField] private int roomCount;
    /*[SerializeField] Transform pickupPrefab;
    [SerializeField] Transform enemyPrefab;*/
    //[SerializeField] PlayerController player;

    Vector3 lastRoomExitPoint;
    // Start is called before the first frame update

    private void Awake()
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
    }

    void SpawnRoom()
    {
        var chosenRoom = levelPrefabs[Random.Range(0, levelPrefabs.Count)];
        var roomStartPos = chosenRoom.Find("StartPoint").position;
        var spawnPosition = lastRoomExitPoint + chosenRoom.position - roomStartPos;
        Transform lastRoomTransform = SpawnRoom(chosenRoom, spawnPosition, Quaternion.identity);
        lastRoomExitPoint = lastRoomTransform.Find("EndPoint").position;
    }

    Transform SpawnRoom(Transform roomPrefab, Vector3 spawnPosition, Quaternion rotation)
    {
        //rotate based on the exit?
        var roomTransform = Instantiate(roomPrefab, spawnPosition, rotation);
        var roomStartPos = roomTransform.Find("StartPoint").position;
        var roomEndPoint = roomTransform.Find("EndPoint");
        if (Mathf.Approximately(roomEndPoint.rotation.eulerAngles.y, 90f))
        {
            //i want the next room to rotate, to snap to this room's endPoint. 
            //the corridor had to rotate 270 degrees to align properly
        }
        var roomEndPos = roomEndPoint.position;
        

        return roomTransform;
    }

    //to be called once the end point of a level has been reached
    public static void SpawnNewLevel()
    {
        //do a coroutine, to wait a few seconds before the new level starts
    }
}

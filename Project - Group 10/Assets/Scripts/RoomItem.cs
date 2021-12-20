using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    public TMP_Text roomName;
    private LobbyManager _manager;

    private void Start()
    {
        _manager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string roomName)
    {
        this.roomName.text = roomName;
    }

    public void OnClickItem()
    {
        _manager.JoinRoom(roomName.text);
    }
    
    
}

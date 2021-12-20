using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    //TODO: Use PlayerPrefs to save character choice
    
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;
    public GameObject playGameButton;

    public RoomItem roomItemPrefab;
    private List<RoomItem> _roomItemsList = new List<RoomItem>();
    public Transform contentObject;
    
    [HideInInspector]public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public float timeBetweenUpdates = 1.5f;
    private float _nextUpdateTime; 

    [Tooltip(
        "The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    private void Awake()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient) // && PhotonNetwork.CurrentRoom.PlayerCount >= 2
        {
            playGameButton.SetActive(true);
        }
        else
        {
            playGameButton.SetActive(false);
        }
    }

    public void OnClickCreateRoom()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() {MaxPlayers = maxPlayersPerRoom, BroadcastPropsChangeToAll = true});
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= _nextUpdateTime)
        {
            UpdateRoomList(roomList);
            _nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (var roomItem in _roomItemsList)
        {
            Destroy(roomItem.gameObject);
        }
        _roomItemsList.Clear();

        foreach (var room in list)
        {
            var newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            _roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void UpdatePlayerList()
    {
        foreach (var playerItem in playerItemsList)
        {
            Destroy(playerItem.gameObject);
        }
        playerItemsList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            var newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);

            if (player.Value.Equals(PhotonNetwork.LocalPlayer))
            {
                newPlayerItem.ApplyLocalChanges();
            }
            
            playerItemsList.Add(newPlayerItem);
        }
    }
}

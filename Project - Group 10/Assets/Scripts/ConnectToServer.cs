using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    [Tooltip(
        "The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    #endregion
    
    #region Private Fields
    
    private readonly string _gameVersion = "1";
    private bool _isConnecting;
    
    #endregion
    
    #region Public Fields

    // [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    // [SerializeField]
    // private GameObject controlPanel;

    public TMP_InputField usernameInput;
    public TMP_Text connectButtonText;

    #endregion
    
    #region MonoBehaviourCallbacks
    
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #endregion

    #region Public Methods
    
        
    //start the connection process
    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            connectButtonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true; 
            _isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = _gameVersion;
            
        }

        // controlPanel.SetActive(false);
        //
        // if (PhotonNetwork.IsConnected)
        // {
        //     PhotonNetwork.JoinRandomRoom();
        // }
        // else
        // {
        //     _isConnecting = PhotonNetwork.ConnectUsingSettings();
        //     PhotonNetwork.GameVersion = _gameVersion;
        // }

    }

    
    #endregion
    
    #region MonobehaviourPunCallbacks Callbacks
    
    public override void OnConnectedToMaster()
    {
        if (_isConnecting)
        {
            SceneManager.LoadScene("Lobby");
            _isConnecting = false;
        }
    }
    
    /*public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        _isConnecting = false;
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom});
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        // #Critical: We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Room for 1");
            PhotonNetwork.LoadLevel("Room for 1");
        }
    }*/
    
    #endregion

}

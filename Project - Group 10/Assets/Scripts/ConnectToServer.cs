using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields
    
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    #endregion
    
    #region Private Fields
    
    private readonly string _gameVersion = "1";
    private bool _isConnecting;
    
    #endregion
    
    #region Public Fields

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

    #endregion

}

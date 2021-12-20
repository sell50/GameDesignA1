using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField joinRoomInputField;
    public TMP_InputField createRoomInputField;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomInputField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomInputField.text);
    }
    
    
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    #region Private Constants

    private const string PlayerNamePrefKey = "PlayerName";

    #endregion

    #region MonoBehaviourCallbacks

    private void Start()
    {
        string defaultName = string.Empty;
        var inputField = this.GetComponent<TMP_InputField>();
        if (inputField != null)
        {
            if (PlayerPrefs.HasKey(PlayerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(PlayerNamePrefKey);
                inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    #endregion

    #region Public Methods

    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player name is null or empty");
            return;
        }

        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(PlayerNamePrefKey, value);

    }

    #endregion
}

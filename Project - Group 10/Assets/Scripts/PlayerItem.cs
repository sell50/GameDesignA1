using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;

    //public Image backgroundImage;
    /*public Color highlightColor;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;*/
    public GameObject characterChoiceToggles;

    public TMP_Text characterChosenText;
    /*public Toggle warriorToggle;
    public Toggle grenadierToggle;
    public Toggle iceMageToggle;
    public Toggle fireMageToggle;*/

    private bool _warriorChosen;
    private bool _grenadierChosen;
    private bool _iceMageChosen;
    private bool _fireMageChosen;
    
    private Hashtable playerProperties = new Hashtable();
    private Player _player;
    public void SetPlayerInfo(Player player)
    {
        playerName.text = player.NickName;
        _player = player;
        UpdatePlayerItem(_player);
    }
    public void SetGrenadierChoice()
    {
        _grenadierChosen = true;
        _iceMageChosen = false;
        _warriorChosen = false;
        _fireMageChosen = false;

        playerProperties["playerClass"] = 0;
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    
    public void SetWarriorChoice()
    {
        _warriorChosen = true;
        _iceMageChosen = false;
        _fireMageChosen = false;
        _grenadierChosen = false;

        playerProperties["playerClass"] = 1;
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    
    public void SetIceMageChoice()
    {
        _iceMageChosen = true;
        _fireMageChosen = false;
        _warriorChosen = false;
        _grenadierChosen = false;
        
        playerProperties["playerClass"] = 2;
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    
    public void SetFireMageChoice()
    {
        _fireMageChosen = true;
        _iceMageChosen = false;
        _warriorChosen = false;
        _grenadierChosen = false;
        
        playerProperties["playerClass"] = 3;
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    
    public void ApplyLocalChanges()
    {
        characterChoiceToggles.SetActive(true);
        //backgroundImage.color = highlightColor;
        /*leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);*/
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (_player.Equals(targetPlayer))
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    //TODO: Radio buttons aren't updating on other players' screens
    private void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerClass"))
        {
            switch (player.CustomProperties["playerClass"])
            {
                case 0:
                    characterChosenText.text = "Character Chosen: \n" + "Grenadier";
                    break;
                case 1:
                    characterChosenText.text = "Character Chosen: \n" + "Warrior";
                    break;
                case 2:
                    characterChosenText.text = "Character Chosen: \n" + "Ice Mage";
                    break;
                case 3:
                    characterChosenText.text = "Character Chosen: \n" + "Fire Mage";
                    break;
            }
            playerProperties["playerClass"] = (int) player.CustomProperties["playerClass"];
        }
        else
        {
            playerProperties["playerClass"] = 0;
        }
    }
}

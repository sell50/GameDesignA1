using System.Collections;
using System.Collections.Generic;
using Characters;
using TMPro;
using UnityEngine;

public class ScoresMenu : MonoBehaviour
{
    public TMP_Text L1BossToParty, L2BossToParty, L3BossToParty, L1PartyToBoss, L2PartyToBoss, L3PartyToBoss;
    
    //the level scores 
    void Start()
    {
        var boss = new Boss();
        L1BossToParty.text = PlayerPrefs.GetInt("L1TotalDamageToParty").ToString();
        L2BossToParty.text = PlayerPrefs.GetInt("L2TotalDamagetoParty").ToString();
        L3BossToParty.text = PlayerPrefs.GetInt("L3TotalDamageToParty").ToString();

        L1PartyToBoss.text = PlayerPrefs.GetInt("L1TotalDamageToBoss").ToString();
        L2PartyToBoss.text = PlayerPrefs.GetInt("L2TotalDamageToBoss").ToString();
        L3PartyToBoss.text = PlayerPrefs.GetInt("L3TotalDamageToBoss").ToString();

        /*//Level 3
        if (PlayerPrefs.HasKey("L3TotalDamageToBoss") && PlayerPrefs.HasKey("L3TotalDamageToParty"))
        {
            if (PlayerPrefs.GetInt("L3TotalDamageToBoss") < boss.GetTotalDamageTaken())
            {
                PlayerPrefs.SetInt("L3TotalDamageToBoss", boss.GetTotalDamageTaken());
            }

            if (PlayerPrefs.GetInt("L3TotalDamageToParty") < boss.GetTotalDamageDone())
            {
                PlayerPrefs.SetInt("L3TotalDamageToParty", boss.GetTotalDamageDone());
            }
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("L3TotalDamageToBoss", boss.GetTotalDamageTaken());
            PlayerPrefs.SetInt("L3TotalDamageToParty", boss.GetTotalDamageDone());
            PlayerPrefs.Save();
        }
        
        //Level 2
        if (PlayerPrefs.HasKey("L2TotalDamageToBoss") && PlayerPrefs.HasKey("L2TotalDamageToParty"))
        {
            if (PlayerPrefs.GetInt("L2TotalDamageToBoss") < boss.GetTotalDamageTaken())
            {
                PlayerPrefs.SetInt("L2TotalDamageToBoss", boss.GetTotalDamageTaken());
            }

            if (PlayerPrefs.GetInt("L2TotalDamageToParty") < boss.GetTotalDamageDone())
            {
                PlayerPrefs.SetInt("L2TotalDamageToParty", boss.GetTotalDamageDone());
            }
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("L2TotalDamageToBoss", boss.GetTotalDamageTaken());
            PlayerPrefs.SetInt("L2TotalDamageToParty", boss.GetTotalDamageDone());
            PlayerPrefs.Save();
        }
        
        //Level 1
        if (PlayerPrefs.HasKey("L1TotalDamageToBoss") && PlayerPrefs.HasKey("L1TotalDamageToParty"))
        {
            if (PlayerPrefs.GetInt("L1TotalDamageToBoss") < boss.GetTotalDamageTaken())
            {
                PlayerPrefs.SetInt("L1TotalDamageToBoss", boss.GetTotalDamageTaken());
            }

            if (PlayerPrefs.GetInt("L1TotalDamageToParty") < boss.GetTotalDamageDone())
            {
                PlayerPrefs.SetInt("L1TotalDamageToParty", boss.GetTotalDamageDone());
            }
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("L1TotalDamageToBoss", boss.GetTotalDamageTaken());
            PlayerPrefs.SetInt("L1TotalDamageToParty", boss.GetTotalDamageDone());
            PlayerPrefs.Save();
        }*/
        
    }
}

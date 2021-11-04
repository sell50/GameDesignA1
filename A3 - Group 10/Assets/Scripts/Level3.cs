using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Characters;
using System.IO;

public class Level3 : MonoBehaviour
{
    public TMP_Text healthBoss, healthMage, healthWarrior, healthmoon, healthRog, healthPri;
    
    //Boss
    Boss boss = new Boss();
    
    //DPS
    MoonkinDruid moon = new MoonkinDruid();
    Mage mage = new Mage();
    Warrior war = new Warrior();
    Rogue rog = new Rogue();
    
    //Healer
    Priest priest = new Priest();


    int timestep = 0;

    void Update()
    {

        healthBoss.text = "Boss HP: " + boss.health + " Damage: " + boss.GetTotalDamageTaken();
        healthMage.text = "Mage HP: " + mage.health + " Damage: " + mage.GetTotalDamageTaken();
        healthmoon.text = "Moonkin Druid HP: " + moon.health + " Damage: " + moon.GetTotalDamageTaken(); ;
        healthWarrior.text = "Warrior HP: " + war.health + " Damage: " + war.GetTotalDamageTaken(); ;
        healthRog.text = "Rogue HP: " + rog.health + " Damage: " + rog.GetTotalDamageTaken(); ;
        healthPri.text = "Priest HP: " + priest.health;

        
        boss.DealDamage(mage);
        boss.DealDamage(moon);
        boss.DealDamage(war);
        boss.DealDamage(rog);
        boss.DealDamage(priest);

        boss.DealDamagePerStep(war);
        boss.CleanDamagePerStep();
        


        mage.DealDamage(boss);
        moon.DealDamage(boss);
        war.DealDamage(boss);
        rog.DealDamage(boss);
        priest.DealDamage(boss);

        var chooseCharacter = UnityEngine.Random.Range(1, 6);

        if (chooseCharacter == 1 || chooseCharacter == 2)
        {
            priest.SmallHeal(priest);
        }

        if (chooseCharacter == 3)
        {
            priest.SmallHeal(war);
        }

        if (chooseCharacter == 4)
        {
            priest.SmallHeal(rog);
        }

        if (chooseCharacter == 5)
        {
            priest.SmallHeal(mage);
        }

        if (chooseCharacter == 6)
        {
            priest.SmallHeal(moon);
        }

        priest.BigHeal(war);

        if (boss.health <= 0 || mage.health <= 0 || moon.health <= 0 || war.health <= 0 || priest.health <= 0 || rog.health <= 0)
        {
            //Scores
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
            }
            enabled = false;
        }

        CSVWriter();

    }

    void CSVWriter(){

        if (File.Exists("Level3.csv")) { File.Delete("Level3.csv"); }
        string filename = "Level3.csv";
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine("Boss" + "," + boss.health);
        tw.WriteLine("Warrior" + "," + boss.health);
        tw.WriteLine("Rogue" + "," + boss.health);
        tw.WriteLine("Mage" + "," + boss.health);
        tw.WriteLine("Moonkin Druid" + "," + boss.health);
        tw.WriteLine("Priest" + "," + boss.health);
        timestep++;
        tw.Close();
        }

}

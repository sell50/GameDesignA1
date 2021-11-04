using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Characters;
using System.IO;

    public class Level1 : MonoBehaviour
    {
        public TMP_Text healthBoss, healthMage, healthWarrior, healthMD, healthRog, healthPri;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Rogue rog = new Rogue();
        Priest pri = new Priest();
        int timestep = 0;
    //PlayerPrefs.SetInt("highscore", 0);

    void Update()
    {
        healthBoss.text = "Boss: " + boss.health + " Damage: " + boss.GetTotalDamageTaken();
        healthMage.text = "Mage: " + mage.health + " Damage: " + mage.GetTotalDamageTaken();
        healthMD.text = "Moonkin Druid: " + md.health + " Damage: " + md.GetTotalDamageTaken(); ;
        healthWarrior.text = "Warrior: " + war.health + " Damage: " + war.GetTotalDamageTaken(); ;
        healthRog.text = "Rogue: " + rog.health + " Damage: " + rog.GetTotalDamageTaken(); ;
        healthPri.text = "Priest: " + pri.health;

        boss.DealDamage(mage);
        boss.DealDamage(md);
        boss.DealDamage(war);
        boss.DealDamage(rog);
        boss.DealDamage(pri);

        mage.DealDamage(boss);
        md.DealDamage(boss);
        war.DealDamage(boss);
        rog.DealDamage(boss);
        pri.DealDamage(boss);

        var chooseCharacter = UnityEngine.Random.Range(1, 6);

        if (chooseCharacter == 1 || chooseCharacter == 2)
        {
            pri.SmallHeal(pri);
        }

        if (chooseCharacter == 3)
        {
            pri.SmallHeal(war);
        }

        if (chooseCharacter == 4)
        {
            pri.SmallHeal(rog);
        }

        if (chooseCharacter == 5)
        {
            pri.SmallHeal(mage);
        }

        if (chooseCharacter == 6)
        {
            pri.SmallHeal(md);
        }

        pri.BigHeal(war);

        if (boss.health <= 0 || mage.health <= 0 || md.health <= 0 || war.health <= 0 || pri.health <= 0 || rog.health <= 0)
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
        //if (boss.GetTotalDamage() > highscore)
        //{
        //    PlayerPrefs.SetInt("highscore", boss.GetTotalDamage());
        //}

        void CSVWriter()
            {
                string filename = "Level1.csv";
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

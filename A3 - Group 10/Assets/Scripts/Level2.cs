using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Characters;

    public class Level2 : MonoBehaviour
    {

        public Text healthBoss, healthMage, healthWarrior, healthMD, healthPriest, healthRogue;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Priest priest = new Priest();
        Rogue rogue = new Rogue();
        bool running = true;
        int timestep = 1;

        void Update()
        {

            if (running == true)
            {
                healthBoss.text = "Boss: " + boss.health + "\nDamage: " + boss.GetTotalDamageDone(); ;
                healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamageDone();
                healthMD.text = "Moonkin Druid: " + md.health + "\nDamage: " + md.GetTotalDamageDone(); ;
                healthWarrior.text = "Warrior: " + war.health + "\nDamage: " + war.GetTotalDamageDone(); ;
                healthPriest.text = "Priest: " + priest.health + "\nDamage: " + priest.GetTotalDamageDone(); ;
                healthRogue.text = "Rogue: " + rogue.health + "\nDamage: " + rogue.GetTotalDamageDone(); ;
                boss.DealDamage(mage); boss.DealDamage(md); boss.DealDamage(war); boss.DealDamage(priest); boss.DealDamage(rogue);
                mage.DealDamage(boss);
                md.DealDamage(boss);
                war.DealDamage(boss);
                priest.DealDamage(boss);
                rogue.DealDamage(boss);
                if (boss.health <= 0 || mage.health <= 0 || md.health <= 0 || war.health <= 0 || priest.health <= 0 || rogue.health <= 0)
                {
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
                        running = false;
                }

                if (war.health <= 1500)
                {
                    int heal = Random.Range(1, 2);
                    switch (heal)
                    {
                        case 1: { priest.SmallHeal(war); priest.mana += 5; break; }
                        case 2: { priest.BigHeal(war); priest.mana += 10; break; }
                    }
                }
            CSVWriter();
        }

        
    }
    void CSVWriter()
    {

        if (timestep==1 && File.Exists("Level2.csv"))
        {
            File.Delete("Level2.csv");
        }
        string filename = "Level2.csv";
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine("Timestep" + "," + timestep);
        tw.WriteLine("Boss" + "," + boss.health);
        tw.WriteLine("Warrior" + "," + war.health);
        tw.WriteLine("Rogue" + "," + rogue.health);
        tw.WriteLine("Mage" + "," + mage.health);
        tw.WriteLine("Moonkin Druid" + "," + md.health);
        tw.WriteLine("Priest" + "," + priest.health);
        timestep++;
        tw.Close();        
    }
        
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Characters;

    public class Level1 : MonoBehaviour
    {
        public TMP_Text healthBoss, healthMage, healthWarrior, healthMD, healthRog, healthPri;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Rogue rog = new Rogue();
        Priest pri = new Priest();
        //PlayerPrefs.SetInt("highscore", 0);
        

        void Update()
        {
            healthBoss.text = "Boss: " + boss.health + "\nDamage: " + boss.GetTotalDamageTaken();
            healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamageTaken();
            healthMD.text = "Moonkin Druid: " + md.health + "\nDamage: ";
            healthWarrior.text = "Warrior: " + war.health + "\nDamage: ";
            healthRog.text = "Rogue: " + rog.health + "\nDamage: ";
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

            if (boss.health == 0 || mage.health == 0 || md.health == 0 || war.health == 0 || pri.health == 0 || rog.health == 0)
            {
                /*boss.gameObject.SetActive(false);
                mage.gameObject.SetActive(false);
                md.gameObject.SetActive(false);
                rog.gameObject.SetActive(false);
                war.gameObject.SetActive(false);
                pri.gameObject.SetActive(false);*/
            }

            //if (boss.GetTotalDamage() > highscore)
            //{
            //    //PlayerPrefs.SetInt("highscore", boss.GetTotalDamage());
            //}
        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Characters
{
    public class Level2 : BasicCharacter
    {

        public Text healthBoss, healthMage, healthWarrior, healthMD, healthRog, health Prist;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Rogue rog = new Rogue();
        Priest pri = new Priest();
        //PlayerPrefs.SetInt("highscore", 0);

        void Update()
        {
            healthBoss.text = "Boss: " + boss.health + "\nDamage: ";
            healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamage();
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

            if (boss.health == 0 || mage.health == 0 || md.health == 0 || war.health == 0)
            {
                boss.GameObject.SetActive(false);
                mage.GameObject.SetActive(false);
                md.GameObject.SetActive(false);
                rog.GameObject.SetActive(false);
                war.GameObject.SetActive(false);
                pri.GameObject.SetActive(false);
            }

            if (boss.GetTotalDamage() > highscore)
            {
                //PlayerPrefs.SetInt("highscore", boss.GetTotalDamage());
            }
        }
    }
}

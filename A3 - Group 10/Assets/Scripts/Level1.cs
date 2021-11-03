using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Characters
{
    public class Level1 : BasicCharacter
    {
        public Text healthBoss, healthMage, healthWarrior, healthMD, healthRog, health Prist;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Rogue rog = new Rogue();
        Priest pri = new Priest();
        PlayerPrefs.SetInt("highscore", 0);

        void Update()
        {
            healthBoss.text = "Boss: " + boss.health + "\nDamage: " + boss.GetTotalDamage();
            healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamage();
            healthMD.text = "Moonkin Druid: " + md.health + "\nDamage: " + md.GetTotalDamage();
            healthWarrior.text = "Warrior: " + war.health + "\nDamage: " + war.GetTotalDamage();
            healthRog.text = "Rogue: " + rog.health + "\nDamage: " + rog.GetTotalDamage();
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
                boss.gameObject.SetActive(false);
                mage.gameObject.SetActive(false);
                md.GameObject.SetActive(false);
                rog.gameObject.SetActive(false);
                war.gameObject.SetActive(false);
                pri.gameObject.SetActive(false);
            }

            if (boss.GetTotalDamage() > highscore)
            {
                PlayerPrefs.SetInt("highscore", boss.GetTotalDamage());
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Characters
{
    public class Level2 : BasicCharacter
    {

        public Text healthBoss, healthMage, healthWarrior, healthMD;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        PlayerPrefs.SetInt("highscore", 0); 

        void Update()
        {
           healthBoss.text = "Boss: " + boss.health + "\nDamage: ";
           healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamage();
           healthMD.text = "Moonkin Druid: " + md.health + "\nDamage: ";
           healthWarrior.text = "Warrior: " + war.health + "\nDamage: ";
           boss.DealDamage(mage);
           mage.DealDamage(boss);
           if(boss.health == 0 || mage.health == 0 || md.health == 0 || war.health == 0)
            {

            }
            if (boss.GetTotalDamage()> highscore)
            {
                PlayerPrefs.SetInt("highscore", boss.GetTotalDamage());
            }
            if (war.health <= 1500)
            {
                int heal = Random.Range(1, 2);
                switch (heal)
                {
                    case 1: { SmallHeal(war); mana += 5 break; }
                    case 2: { BigHeal(war); mana += 10; break; }
                }
            }

          
        }
    }
}

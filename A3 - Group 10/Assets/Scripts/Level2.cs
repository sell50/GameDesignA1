using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Characters
{
    public class Level2 : BasicCharacter
    {

        public Text healthBoss, healthMage, healthWarrior, healthMD, healthPriest, healthRogue;
        Boss boss = new Boss();
        MoonkinDruid md = new MoonkinDruid();
        Mage mage = new Mage();
        Warrior war = new Warrior();
        Priest priest = new Priest();
        Rogue rogue = new Rogue();

        void Update()
        {
            healthBoss.text = "Boss: " + boss.health + "\nDamage: " + boss.GetTotalDamage(); ;
            healthMage.text = "Mage: " + mage.health + "\nDamage: " + mage.GetTotalDamage();
            healthMD.text = "Moonkin Druid: " + md.health + "\nDamage: " + md.GetTotalDamage(); ;
            healthWarrior.text = "Warrior: " + war.health + "\nDamage: " + war.GetTotalDamage(); ;
            healthPriest.text = "Priest: " + priest.health + "\nDamage: " + priest.GetTotalDamage(); ;
            healthRogue.text = "Rogue: " + rogue.health + "\nDamage: " + rogue.GetTotalDamage(); ;
            boss.DealDamage(mage); boss.DealDamage(md); boss.DealDamage(war); boss.DealDamage(priest); boss.DealDamage(rogue);
            mage.DealDamage(boss);
            md.DealDamage(boss);
            war.DealDamage(boss);
            priest.DealDamage(boss);
            rogue.DealDamage(boss);
            if (boss.health == 0 || mage.health == 0 || md.health == 0 || war.health == 0 || priest.health==0 || rogue.health==0)
            {

            }

            if (war.health <= 1500)
            {
                int heal = Random.Range(1, 2);
                switch (heal)
                {
                    case 1: { priest.SmallHeal(war); mana += 5; break; }
                    case 2: { priest.BigHeal(war); mana += 10; break; }
                }
            }


        }
    }
}

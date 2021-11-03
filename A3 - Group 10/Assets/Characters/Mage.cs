using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Characters
{
    public class Mage : BasicCharacter
    {
        public Mage()
        {
            health = 1000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            var damage = 0;
            if(opponent is Boss)
            {
                damage = Random.Range(5, 30);
                opponent.ReduceHealth(damage);
            }

            totalDamageDone += damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Characters
{
    public class Mage : BasicCharacter
    {
        void Start()
        {
            health = 1000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if(opponent is Boss)
            {
                int damage = Random.Range(5, 30);
                opponent.ReduceHealth(damage);
            }
        }
    }
}

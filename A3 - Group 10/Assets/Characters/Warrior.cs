using UnityEngine;

namespace Characters
{
    public class Warrior : BasicCharacter
    {
        public Warrior()
        {
            health = 3000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            var damage = 0;
            if (opponent is Boss)
            {
                damage = Random.Range(5, 10);
                opponent.ReduceHealth(damage);
            }

            totalDamageDone += damage;
        }
    }
}
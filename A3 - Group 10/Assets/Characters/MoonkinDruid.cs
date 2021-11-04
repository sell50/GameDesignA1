using UnityEngine;

namespace Characters
{
    public class MoonkinDruid : BasicCharacter
    {

        public MoonkinDruid()
        {
            health = 1250;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            var damage = 0;
            if (opponent is Boss)
            {
                damage = Random.Range(5, 15);
                opponent.ReduceHealth(damage);
            }

            totalDamageDone += damage;
        }
    }
}

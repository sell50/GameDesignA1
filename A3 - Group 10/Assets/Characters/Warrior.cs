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
            if (opponent is Boss)
            {
                opponent.ReduceHealth(Random.Range(5, 10));
            }
        }
    }
}
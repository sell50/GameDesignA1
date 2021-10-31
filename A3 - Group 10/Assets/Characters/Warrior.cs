using UnityEngine;

namespace Characters
{
    public class Warrior : BasicCharacter
    {
        void Start()
        {
            health = 3000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Boss)
            {
                var damage = Random.Range(5, 10);
                opponent.ReduceHealth(damage);
            }
        }
    }
}
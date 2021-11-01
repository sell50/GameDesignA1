using UnityEngine;

namespace Characters
{
    public class MoonkinDruid : BasicCharacter
    {
        private int damage = 0;

        void Start()
        {
            health = 1250;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Boss)
            {
                damage = Random.Range(5, 15);
                opponent.ReduceHealth(damage);
            }
        }
    }
}

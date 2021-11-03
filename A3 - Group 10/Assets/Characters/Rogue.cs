using UnityEngine;

namespace Characters
{
    public class Rogue : BasicCharacter
    {
        // Start is called before the first frame update
        public Rogue()
        {
            health = 1500;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            var damage = 0;
            if (opponent is Boss)
            {
                damage = Random.Range(15, 25);
                opponent.ReduceHealth(damage);
            }

            totalDamageDone += damage;
        }
    }
}

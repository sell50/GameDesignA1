using UnityEngine;

namespace Characters
{
    public class Rogue : BasicCharacter
    {
        // Start is called before the first frame update
        void Start()
        {
            health = 1500;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Boss)
            {
                opponent.ReduceHealth(Random.Range(15, 25));
            }
        }
    }
}

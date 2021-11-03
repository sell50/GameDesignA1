using UnityEngine;

namespace Characters
{
    public class MoonkinDruid : BasicCharacter
    {

        void Start()
        {
            health = 1250;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Boss)
            {
                
                opponent.ReduceHealth(Random.Range(5, 15));
            }
        }
    }
}

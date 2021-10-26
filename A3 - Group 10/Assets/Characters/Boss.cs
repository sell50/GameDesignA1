using UnityEngine;

namespace Characters
{
    public class Boss : BasicCharacter
    {
        void Start()
        {
            health = 5000;
            
        }


        void Update()
        {
        
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Warrior)
            {
                //create randomNumGen for damage
                opponent.ReduceHealth(0);
            }
        }
    }
}

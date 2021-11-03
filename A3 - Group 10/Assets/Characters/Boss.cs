using System.Security.Cryptography;
using UnityEngine;

namespace Characters
{
    public class Boss : BasicCharacter
    {
        public Boss()
        {
            health = 5000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Warrior)
            {
                opponent.ReduceHealth(Random.Range(40, 50));
            } else if (opponent is Rogue || opponent is Mage || opponent is MoonkinDruid || opponent is Priest)
            {
                opponent.ReduceHealth(Random.Range(5, 20));
            }
        }
    }
}
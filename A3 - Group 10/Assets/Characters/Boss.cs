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
            var damage = 0;
            if (opponent is Warrior)
            {
                damage = Random.Range(40, 50);
                opponent.ReduceHealth(damage);
            } else if (opponent is Rogue || opponent is Mage || opponent is MoonkinDruid || opponent is Priest)
            {
                damage = Random.Range(5, 20);
                opponent.ReduceHealth(damage);
            }

            totalDamageDone += damage;
        }
    }
}
using System.Security.Cryptography;
using UnityEngine;

namespace Characters
{
    public class Boss : BasicCharacter
    {
        void Start()
        {
            health = 5000;
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            if (opponent is Warrior)
            {
                var damage = Random.Range(40, 50);
                opponent.ReduceHealth(damage);
            }
            //TODO include damage to damage-dealers and healer when I have access to those characters 
        }
    }
}
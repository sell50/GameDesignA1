using UnityEngine;

namespace Characters
{
    public class BasicCharacter
    {
        public int health;
        public int mana;
        public int damage, totalDamageTaken, totalDamageDone;

        public virtual void DealDamage(BasicCharacter opponent) { }

        public void ReduceHealth(int damageDealt)
        {
            health -= damageDealt;
            totalDamageTaken += damageDealt;
        }

        public void IncreaseHealth(int hpHealed)
        {
            health += hpHealed;
        }

        public int GetTotalDamageTaken()
        {
            return totalDamageTaken;
        }

        public int GetTotalDamageDone()
        {
            return totalDamageDone;
        }
    }
}


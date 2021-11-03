using UnityEngine;

namespace Characters
{
    public class BasicCharacter
    {
        public int health;
        public int mana;
        public int damage, totalDamage = 0;

        public virtual void DealDamage(BasicCharacter opponent) { }

        public void ReduceHealth(int damageDealt)
        {
            health -= damageDealt;
            totalDamage += damageDealt;
        }

        public void IncreaseHealth(int hpHealed)
        {
            health += hpHealed;
        }

        public int GetTotalDamage()
        {
            
            return totalDamage;
        }
    }
}


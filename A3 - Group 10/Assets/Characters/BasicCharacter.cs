using UnityEngine;

namespace Characters
{
    public class BasicCharacter : MonoBehaviour
    {
        public int health;
        public int mana;
        public int damage, totalDamage = 0;

        //is declared here but will be implemented in the other Character scripts, to take into account
        public virtual void DealDamage(BasicCharacter opponent) { }

        public void ReduceHealth(int damageDealt)
        {
            health -= damageDealt;
        }

        public void IncreaseHealth(int hpHealed)
        {
            health += hpHealed;
        }

        public int GetTotalDamage()
        {
            totalDamage = totalDamage + damage;
            return totalDamage;
        }
    }
}


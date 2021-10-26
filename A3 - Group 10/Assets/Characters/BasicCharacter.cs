using UnityEngine;

namespace Characters
{
    public class BasicCharacter : MonoBehaviour
    {
        public int health;
        public int mana;

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
    }
}


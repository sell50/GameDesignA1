using UnityEngine;

namespace Characters
{
    public class Priest : BasicCharacter
    {

        public Priest()
        {
            health = 900;
            mana = 1000;
        }

        public void SmallHeal(BasicCharacter opponent)
        {
            var heal = 15;
            opponent.IncreaseHealth(heal);
            mana -= 5;
        }

        public void BigHeal(BasicCharacter opponent)
        {
            var heal = 25;
            if (opponent is Warrior)
            {
                opponent.IncreaseHealth(heal);
                mana -= 10;
            }
        }


    }
}
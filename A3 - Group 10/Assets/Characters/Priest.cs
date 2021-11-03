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


        void Update()
        {
            if (health < 0)
            {

                var chooseCharacter = Random.Range(1, 6);

                if (chooseCharacter == 1 || chooseCharacter == 2)
                {
                    SmallHeal(Priest);
                }

                if (chooseCharacter == 3)
                {
                    SmallHeal(Warrior);
                }

                if (chooseCharacter == 4)
                {
                    SmallHeal(Rogue);
                }

                if (chooseCharacter == 5)
                {
                    SmallHeal(Mage);
                }

                if (chooseCharacter == 6)
                {
                    SmallHeal(Moonkin);
                }
                
                mana += 3;

                
            }

            else
            {
                //end simulation
            }
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
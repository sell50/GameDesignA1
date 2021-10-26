namespace Characters
{
    public class Warrior : BasicCharacter
    {
        void Start()
        {
            health = 3000;
        }
        
        void Update()
        {
        
        }

        public override void DealDamage(BasicCharacter opponent)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
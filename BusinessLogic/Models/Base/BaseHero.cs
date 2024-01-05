namespace BusinessLogic.Models.Base
{
    public abstract class BaseHero : IHero
    {
        public int ID { get; set; }
        
        public abstract string HeroTypeName { get; }
        
        public abstract int MaxHealth { get; }
        
        public double Health { get; set; }

        private const int REST_HEALTH_VALUE = 10;

        public BaseHero(int id)
        {
            ID = id;
            Health = MaxHealth;
        }

        public abstract bool CanDefense(IHero enemy);

        public abstract bool CanBlockAndStrikeBack(IHero enemy);

        public void Attack(IHero enemy)
        {
            if (enemy.CanBlockAndStrikeBack(this))
            {
                Kill(this);
            }
            else if(!enemy.CanDefense(this))
            {
                Kill(enemy);
            }

            Health = Health / 2;
            enemy.Health = enemy.Health / 2;
        }

        public void Rest()
        {
            if(Health + REST_HEALTH_VALUE > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += REST_HEALTH_VALUE; 
            }
        }

        public bool isDead()
        {
            return Health < (double)MaxHealth / 4;
        }

        private void Kill(IHero enemy)
        {
            enemy.Health = 0;
        }
    }
}

namespace BusinessLogic.Models.Base
{
    public interface IHero
    {
        int ID { get; set; }

        string HeroTypeName { get; }

        int MaxHealth { get; }

        double Health { get; set; }

        void Attack(IHero enemy);

        bool CanBlockAndStrikeBack(IHero enemy);

        bool CanDefense(IHero enemy);

        void Rest();

        bool isDead();
    }
}

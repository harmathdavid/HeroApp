using BusinessLogic.Models.Base;

namespace BusinessLogic.Models
{
    public class Archer : BaseHero
    {
        public Archer(int id) : base(id)
        {
        }

        public override int MaxHealth => 100;

        public override string HeroTypeName => "Archer";

        public override bool CanBlockAndStrikeBack(IHero enemy)
        {
            return false;
        }

        public override bool CanDefense(IHero enemy)
        {
            return false;
        }
    }
}

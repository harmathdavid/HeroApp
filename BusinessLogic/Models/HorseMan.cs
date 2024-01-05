using BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class HorseMan : BaseHero
    {
        private readonly Random _generator;

        private const double DEFENSE_CHANCE = 0.6;

        public HorseMan(int id) : base(id)
        {
            _generator = new Random();
        }

        public override int MaxHealth => 150;

        public override string HeroTypeName => "Horse man";

        public override bool CanBlockAndStrikeBack(IHero enemy)
        {
            return false;
        }

        public override bool CanDefense(IHero enemy)
        {
            bool result = false;

            if(enemy is Archer)
            {
                double randomNumber = _generator.NextDouble();
                result = randomNumber < DEFENSE_CHANCE;
            }
            else if(enemy is SwordMan)
            {
                result = true;
            }
            else if(enemy is HorseMan)
            {
                result = false;
            }


            return result;
        }
    }
}

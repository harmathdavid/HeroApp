using BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class SwordMan : BaseHero
    {
        public override int MaxHealth => 120;

        public override string HeroTypeName => "Sword man";

        public SwordMan(int id) : base(id)
        {
        }


        public override bool CanBlockAndStrikeBack(IHero enemy)
        {
            return enemy is HorseMan;
        }

        public override bool CanDefense(IHero enemy)
        {
            bool result = false;

            if(enemy is Archer || enemy is SwordMan)
            {
                result = false;
            }
            else if(enemy is HorseMan)
            {
                result = true;
            }

            return result;
        }
    }
}

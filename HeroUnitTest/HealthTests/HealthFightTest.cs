using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeroUnitTest.HealthTest
{
    [TestClass]
    public class HealthFightTest
    {
        [TestMethod]
        public void Rest()
        {
            IHero archer = new Archer(1);
            archer.Health -= 30;

            double healthBeforeRest = archer.Health;

            archer.Rest();

            Assert.IsTrue(healthBeforeRest + 10 == archer.Health);
        }

        [TestMethod]
        public void RestOverMaxHealth()
        {
            IHero archer = new Archer(1);
            archer.Rest();

            Assert.IsTrue(archer.Health == archer.MaxHealth);
        }

        [TestMethod]
        public void HealthAfterAttack()
        {
            IHero swordMan = new SwordMan(1);
            IHero archer = new Archer(2);

            double healthBeforeAttack = swordMan.Health;
            swordMan.Attack(archer);

            Assert.IsTrue(swordMan.Health == healthBeforeAttack / 2);
        }

        [TestMethod]
        public void IsDead()
        {
            IHero swordMan = new SwordMan(1);
            swordMan.Health = 1;

            Assert.IsTrue(swordMan.isDead() && swordMan.Health < swordMan.MaxHealth / 4);
        }
    }
}

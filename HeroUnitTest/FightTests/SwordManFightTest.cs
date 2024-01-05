using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using HeroUnitTest.FightTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeroUnitTest.FightTests
{
    [TestClass]
    public class SwordManFightTest : BaseHeroFightTest
    {
        [TestMethod]
        public override void AttackArcher()
        {
            IHero hero = new SwordMan(1);
            IHero enemy = new Archer(2);

            hero.Attack(enemy);

            Assert.IsTrue(enemy.isDead());
        }

        [TestMethod]
        public override void AttackHorseMan()
        {
            IHero hero = new SwordMan(1);
            IHero enemy = new HorseMan(2);

            hero.Attack(enemy);

            Assert.IsTrue(!enemy.isDead());
        }

        [TestMethod]
        public override void AttackSwordMan()
        {
            IHero hero = new SwordMan(1);
            IHero enemy = new SwordMan(2);

            hero.Attack(enemy);

            Assert.IsTrue(enemy.isDead());
        }

        [TestMethod]
        public override void DefenseArcher()
        {
            IHero enemy = new Archer(1);
            IHero hero = new SwordMan(2);

            enemy.Attack(hero);

            Assert.IsTrue(hero.isDead());
        }

        [TestMethod]
        public override void DefenseHorseMan()
        {
            IHero enemy = new HorseMan(1);
            IHero hero = new SwordMan(2);

            enemy.Attack(hero);

            Assert.IsTrue(enemy.isDead());
        }

        [TestMethod]
        public override void DefenseSwordMan()
        {
            IHero enemy = new SwordMan(1);
            IHero hero = new SwordMan(2);

            enemy.Attack(hero);

            Assert.IsTrue(hero.isDead());
        }
    }
}

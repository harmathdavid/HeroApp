using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using HeroUnitTest.FightTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HeroUnitTest.FightTests
{
    [TestClass]
    public class ArcherFightTest : BaseHeroFightTest
    {
        [TestMethod]
        public override void AttackArcher()
        {
            IHero archer = new Archer(1);
            IHero enemy = new Archer(2);

            archer.Attack(enemy);

            Assert.IsTrue(enemy.isDead());
        }

        //100 támadásból 40x meghal a lovas
        [TestMethod]
        public override void AttackHorseMan()
        {
            List<int> tryCountList = new();
            for (int tryCount = 0; tryCount < 10; tryCount++)
            {
                int numberOfHorseManDeath = 0;
                for (int i = 0; i < 100; i++)
                {
                    IHero archer = new Archer(1);
                    IHero enemy = new HorseMan(2);
                    archer.Attack(enemy);

                    if (enemy.isDead())
                    {
                        numberOfHorseManDeath++;
                    }

                }

                tryCountList.Add(numberOfHorseManDeath);
            }

            double average = tryCountList.Average();
            Assert.IsTrue(average <= 50 && average >= 30);
        }

        [TestMethod]
        public override void AttackSwordMan()
        {
            IHero archer = new Archer(1);
            IHero enemy = new SwordMan(2);

            archer.Attack(enemy);

            Assert.IsTrue(enemy.isDead());
        }

        [TestMethod]
        public override void DefenseArcher()
        {
            IHero enemy = new Archer(1);
            IHero archer = new Archer(2);

            enemy.Attack(archer);

            Assert.IsTrue(archer.isDead());
        }

        [TestMethod]
        public override void DefenseHorseMan()
        {
            IHero enemy = new HorseMan(1);
            IHero archer = new Archer(2);

            enemy.Attack(archer);

            Assert.IsTrue(archer.isDead());
        }

        [TestMethod]
        public override void DefenseSwordMan()
        {
            IHero enemy = new SwordMan(1);
            IHero archer = new Archer(2);

            enemy.Attack(archer);

            Assert.IsTrue(archer.isDead());
        }
    }
}

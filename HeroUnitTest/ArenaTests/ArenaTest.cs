using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeroUnitTest.HealthTest
{
    [TestClass]
    public class ArenaTest
    {
        [TestMethod]
        public void ArenaInitTest()
        {
            int numberOfHeroes = 30;
            IArena arena = new Arena();
            arena.GenerateHeroes(numberOfHeroes);

            Assert.IsTrue(arena.ID > 0 && arena.Heroes.Count == numberOfHeroes);
        }


        [TestMethod]
        public void ArenaInitExceptionTest()
        {
            int numberOfHeroes = 1;
            IArena arena = new Arena();

            Assert.ThrowsException<AtLeastOneHeroPerArenaException>(() => arena.GenerateHeroes(numberOfHeroes));
        }

        [TestMethod]
        public void DeadHeroTest()
        {
            int numberOfHeroes = 30;
            IArena arena = new Arena();
            arena.GenerateHeroes(numberOfHeroes);

            IHero hero = arena.Heroes[0];
            hero.Health -= 1000;

            arena.SetDeadHeroes(hero);

            bool aliveHeroCountValidity = arena.Heroes.Count + 1 == numberOfHeroes;
            bool deadHeroCountValidity = arena.DeadHeroes.Count == 1;

            Assert.IsTrue(aliveHeroCountValidity && deadHeroCountValidity);
        }
    }
}

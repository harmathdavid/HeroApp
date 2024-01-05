using BusinessLogic.Enums;
using BusinessLogic.Exceptions;
using BusinessLogic.Models;
using BusinessLogic.Models.Base;

namespace BusinessLogic
{
    public interface IArena
    {
        int ID { get; }

        List<IHero> Heroes { get; }

        List<IHero> DeadHeroes { get; }

        void SetDeadHeroes(IHero deadHero);

        void GenerateHeroes(int numberOfHeroes);

    }

    public class Arena : IArena
    {
        public int ID { get; private set; }

        public List<IHero> Heroes { get; private set; }

        public List<IHero> DeadHeroes { get; private set; }

        private readonly Random _generator;

        public Arena()
        {
            _generator = new Random();
            Heroes = new List<IHero>();
            DeadHeroes = new List<IHero>();

            ID = _generator.Next();
        }


        public void GenerateHeroes(int numberOfHeroes)
        {
            if(numberOfHeroes <= 1)
            {
                throw new AtLeastOneHeroPerArenaException();
            }

            for (int i = 0; i < numberOfHeroes; i++)
            {
                int heroId = i + 1;
                IHero hero = _generator.Next(1, 4) switch
                {
                    (int)HeroType.Archer => new Archer(heroId),
                    (int)HeroType.SwordMan => new SwordMan(heroId),
                    (int)HeroType.HorseMan => new HorseMan(heroId),
                    _ => throw new NotImplementedException()
                };

                Heroes.Add(hero);
            }
        }

        public void SetDeadHeroes(IHero deadHero)
        {
            Heroes.Remove(deadHero);
            DeadHeroes.Add(deadHero);
        }
    }
}
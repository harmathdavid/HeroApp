using BusinessLogic.Log;
using BusinessLogic.Models.Base;

namespace BusinessLogic
{
    public interface ITournament
    {
        List<IArena> Arenas { get; set; }

        List<string> StartFight(int arenaId);
    }

    public class Tournament : ITournament
    {
        public List<IArena> Arenas { get; set; }

        private readonly Random _generator;

        private readonly ILogger _logger;

        public Tournament()
        {
            Arenas = new List<IArena>();
            _generator = new Random();
            _logger = new Logger();
        }

        public List<string> StartFight(int arenaId)
        {
            List<string> history = new List<string>();

            IArena arena = Arenas.FirstOrDefault(x => x.ID == arenaId);
            if(arena != null)
            {
                int round = 1;

                (IHero? attacker, IHero? defender) fighters = SelectFighters(arena);
                do
                {
                    history.Add(_logger.LogInfo(round, fighters.attacker, fighters.defender));
                    history.Add(_logger.LogBeforeFight(fighters.attacker, fighters.defender));

                    fighters.attacker.Attack(fighters.defender);

                    history.Add(_logger.LogAfterFight(fighters.attacker, fighters.defender));

                    if (fighters.attacker.isDead())
                    {
                        arena.SetDeadHeroes(fighters.attacker);
                    }

                    if (fighters.defender.isDead())
                    {
                        arena.SetDeadHeroes(fighters.defender);
                    }

                    arena.Heroes.ForEach(x => x.Rest());

                    fighters = SelectFighters(arena);

                    round++;
                }
                while (fighters.attacker != null && fighters.defender != null);


                Arenas.Remove(arena);
            }

            return history;
        }

        private (IHero? attacker, IHero? defenderHero) SelectFighters(IArena arena)
        {
            IHero attackerHero = null;
            IHero defenderHero = null;

            if (arena.Heroes.Any())
            {
                int attackerHeroIndex = _generator.Next(0, arena.Heroes.Count);
                attackerHero = arena.Heroes[attackerHeroIndex];

                int? defenderHeroIndex = null;
                if (arena.Heroes.Count > 1)
                {
                    do
                    {
                        defenderHeroIndex = _generator.Next(0, arena.Heroes.Count);
                    }
                    while (defenderHeroIndex == attackerHeroIndex);
                }

                defenderHero = defenderHeroIndex.HasValue ? arena.Heroes[defenderHeroIndex.Value] : null;
            }

            return (attackerHero, defenderHero);
        }

    }
}

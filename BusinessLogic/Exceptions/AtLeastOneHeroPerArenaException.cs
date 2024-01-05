namespace BusinessLogic.Exceptions
{
    public class AtLeastOneHeroPerArenaException : Exception
    {
        public override string Message => "You have to define at least one hero";
    }
    
}

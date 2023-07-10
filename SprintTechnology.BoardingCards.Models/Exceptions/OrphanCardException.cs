namespace SprintTechnology.BoardingCards.Models.Exceptions
{
    public class OrphanCardException : Exception
    {
        public OrphanCardException(string? message) : base(message) { }
    }
}

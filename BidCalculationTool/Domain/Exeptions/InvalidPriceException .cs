namespace Domain.Exeptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException()
            : base("Price must be greater than zero.") { }
    }
}

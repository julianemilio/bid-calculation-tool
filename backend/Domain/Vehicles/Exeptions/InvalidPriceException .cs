namespace Domain.Vehicles.Exeptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException()
            : base("Price must be greater than zero.") { }
    }
}

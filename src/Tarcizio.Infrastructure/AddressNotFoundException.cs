namespace Tarcizio.Infrastructure
{
    public class AddressNotFoundException : InfrastructureException
    {
        internal AddressNotFoundException(string message)
            : base(message)
        { }
    }
}

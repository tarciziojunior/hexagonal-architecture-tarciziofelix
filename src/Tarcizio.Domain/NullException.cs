namespace Tarcizio.Domain
{
    public sealed class NullException : DomainException
    {
        internal NullException(string message)
            : base(message)
        { }
    }
}

namespace Tarcizio.Domain
{
    public sealed class InvalidPhoneException : DomainException
    {
        internal InvalidPhoneException(string message)
            : base(message)
        { }
    }
}

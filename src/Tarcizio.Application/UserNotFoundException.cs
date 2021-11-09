namespace Tarcizio.Application
{
    public sealed class UserNotFoundException : ApplicationException
    {
        internal UserNotFoundException(string message)
            : base(message)
        { }
    }
}

namespace Tarcizio.Application
{
    internal sealed class ZipCodeNotFoundException : ApplicationException
    {
        internal ZipCodeNotFoundException(string message)
            : base(message)
        { }
    }
}

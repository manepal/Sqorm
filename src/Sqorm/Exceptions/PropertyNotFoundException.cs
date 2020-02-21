namespace Sqorm.Exceptions
{
    internal sealed class PropertyNotFoundException : System.Exception
    {
        internal PropertyNotFoundException() {}
        internal PropertyNotFoundException(string message) : base(message) {}
        internal PropertyNotFoundException(string message, System.Exception ex) : base(message, ex) {}
    }
}
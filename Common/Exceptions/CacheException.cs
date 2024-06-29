namespace Common.Exceptions
{
    public class CacheException : Exception
    {
        public CacheException() : base() { }
        public CacheException(string message) : base(message) { }
    }
}

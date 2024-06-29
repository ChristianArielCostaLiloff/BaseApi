﻿namespace Common.BaseApi.Exceptions
{
    public class CacheException : Exception
    {
        public CacheException() : base() { }
        public CacheException(string message) : base(message) { }
    }
}
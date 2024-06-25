using System;

namespace Messenger.Core.Infrastructure.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string? message) { }
    }
}
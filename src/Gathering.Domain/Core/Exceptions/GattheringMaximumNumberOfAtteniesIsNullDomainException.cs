namespace Gathering.Domain.Core.Exceptions;

public sealed class GattheringMaximumNumberOfAtteniesIsNullDomainException : DomainException
{
    public GattheringMaximumNumberOfAtteniesIsNullDomainException(string message) : base(message)
    {}
}


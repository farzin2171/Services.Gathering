namespace Gathering.Domain.Core.Exceptions;

public sealed class InvitationsValidBeforeInHoursException : DomainException
{
    public InvitationsValidBeforeInHoursException(string message) : base(message)
    {
    }
}

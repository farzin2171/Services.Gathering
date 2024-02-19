using Gathering.Domain.Entities;

namespace Gathering.Domain.Repositories;

public interface IAttendeeRepository
{
    Task InsertAsync(Attendee attendee);
    void Update(Attendee attendee);
}


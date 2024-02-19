using Gathering.Data.Database;
using Gathering.Domain.Entities;
using Gathering.Domain.Repositories;

namespace Gathering.Data.Repostitories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly ApplicationDbContext _context;
    public AttendeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task InsertAsync(Attendee attendee)
    {
       await _context.AddAsync(attendee);
    }

    public void Update(Attendee attendee)
    {
       _context.Update(attendee);
    }
}


namespace Gathering.Domain.Entities;

public class User
{
    internal User(){}
    public User(Guid id, 
                string externalId,
                string firstName, 
                string lastName,
                string email)
    {
        Id =id;
        ExternalId =externalId;
        FirstName =firstName;
        LastName =lastName;
        Email =email;

    }
    public Guid Id { get; set; }
    public string ExternalId { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = String.Empty;

    public string Email { get; private set; } = String.Empty;

    public IReadOnlyCollection<GatheringEvent> GatheringEvents { get; private set; }

    public IReadOnlyCollection<Invitation> Invitations { get; private set; }

    public IReadOnlyCollection<Attendee> Attendees { get; private set; }

}


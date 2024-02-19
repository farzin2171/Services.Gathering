using MediatR;

namespace Gathering.Application.Users.CreateUser;

public sealed class CreateUserCommand : IRequest
{

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserCommand"/> class.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="email">The email.</param>
    /// <param name="externalId">The external Id.</param>
    public CreateUserCommand(string firstName,
                             string lastName,
                             string email, 
                             string externalId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ExternalId = externalId;    
    }

    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; }

    public string ExternalId { get; set; }

}


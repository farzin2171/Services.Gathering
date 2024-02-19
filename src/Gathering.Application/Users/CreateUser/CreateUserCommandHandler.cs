using Gathering.Domain.Entities;
using Gathering.Domain.Repositories;
using MediatR;

namespace Gathering.Application.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;

    }
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _repository.Insert(new User(
            Guid.NewGuid(),
             request.Email,
             request.FirstName,
             request.LastName,
             request.ExternalId
        ));

       await _unitOfWork.SaveChangesAsync();
    }
}


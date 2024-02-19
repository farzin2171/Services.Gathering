using Gathering.Data.Database;
using Gathering.Domain.Entities;
using Gathering.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gathering.Data.Repostitories;

public class UesrRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;


    public UesrRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetByEmailAsync(string email) =>
        await _dbContext.Users.FirstOrDefaultAsync(_ => _.Email == email);


    public async Task<User> GetByIdAsync(Guid userId) =>
        await _dbContext.Users.FirstOrDefaultAsync(_ => _.Id == userId);


    public async Task Insert(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<bool> IsEmailUniqueAsync(string email) =>
         await GetByEmailAsync(email) is null ? true : false;

}


namespace Gathering.Data.Database.Configurations;

using Gathering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.HasMany(e => e.GatheringEvents).WithOne().HasForeignKey(e => e.CreatorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.Invitations).WithOne().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.Attendees).WithOne().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

    }
}


namespace Gathering.Data.Database.Configurations;

using Gathering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GatheringTypeConfiguration : IEntityTypeConfiguration<GatheringEvent>
{
    public void Configure(EntityTypeBuilder<GatheringEvent> builder)
    {
        builder.ToTable("GatheringEvent");

        builder.HasKey(e => e.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.CreatorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Attendees).WithOne().HasForeignKey(a=>a.GatheringEventId);
        builder.HasMany(e => e.Invitations).WithOne().HasForeignKey(i=>i.GatheringEventId);

    }
}


namespace Gathering.Data.Database.Configurations;

using Gathering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class InvitationTypeConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("Invitation");

            builder.HasKey(e => e.Id);

            builder.HasOne<User>()
                .WithMany(x => x.Invitations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<GatheringEvent>()
                .WithMany(x => x.Invitations)
                .HasForeignKey(x => x.GatheringEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


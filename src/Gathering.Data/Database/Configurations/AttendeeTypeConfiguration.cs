using Gathering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gathering.Data.Database.Configurations
{
    internal sealed class AttendeeTypeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.HasKey(attendee => attendee.Id);

            builder.HasOne<GatheringEvent>()
                .WithMany()
                .HasForeignKey(attendee => attendee.GatheringEventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(attendee => attendee.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

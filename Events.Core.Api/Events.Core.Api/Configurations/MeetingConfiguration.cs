using Events.Core.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Core.Api.Configurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.HasKey(m => m.Id);
            
            builder.Property(m => m.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");
            
            builder.Property(m => m.Organizer)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(m => m.Date)
                .IsRequired();
            
            builder.Property(m => m.IsPrivate)
                .IsRequired();
            
            builder.Property(m => m.CreatedBy)
                .IsRequired();
            
            builder.HasOne(m => m.Location)
                .WithOne()
                .HasForeignKey<Location>(l => l.MeetupId);
            
            builder.HasMany(m => m.Lectures)
                .WithOne()
                .HasForeignKey(l => l.MeetupId);
        }
    }
}

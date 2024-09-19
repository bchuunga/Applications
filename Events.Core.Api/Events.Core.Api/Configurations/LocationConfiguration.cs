using Events.Core.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Core.Api.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            
            builder.Property(l => l.City)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(l => l.Street)
                .IsRequired()
                .HasColumnType("varchar(150)");
            
            builder.Property(l => l.PostCode)
                .IsRequired()
                .HasColumnType("varchar(10)");
            
            builder.HasOne(l => l.Meetup)
                .WithOne(m => m.Location)
                .HasForeignKey<Location>(l => l.MeetupId);
        }
    }
}

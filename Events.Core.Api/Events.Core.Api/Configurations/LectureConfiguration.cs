using Events.Core.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Core.Api.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            
            builder.Property(l => l.Author)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(l => l.Topic)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(l => l.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");
            
            builder.HasOne(l => l.Meetup)
                .WithMany(m => m.Lectures)
                .HasForeignKey(l => l.MeetupId);
        }
    }
}

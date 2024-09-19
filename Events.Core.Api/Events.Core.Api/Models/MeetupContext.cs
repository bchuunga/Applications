using Events.Core.Api.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Events.Core.Api.Models
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {
        }
        
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MeetingConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());

            modelBuilder.Entity<Meetup>()
                .HasData(new List<Meetup>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Dot Net Users",
                        Organizer = "Microsoft",
                        Date = DateTime.Now.AddDays(10),
                        IsPrivate = true,
                        CreatedBy = new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce")
                    },
                    new()
                    {
                        Id = 2,
                        Name = "SQL Users",
                        Organizer = "Microsoft",
                        Date = DateTime.Now.AddDays(1),
                        IsPrivate = true,
                        CreatedBy = new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce")
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Code Campers",
                        Organizer = "Code Campers",
                        Date = DateTime.Now.AddDays(22),
                        IsPrivate = false,
                        CreatedBy = new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce")
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Wine Lovers",
                        Organizer = "Napa Valley Wine Growers",
                        Date = DateTime.Now.AddDays(100),
                        IsPrivate = true,
                        CreatedBy = new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce")
                    }
                });

            modelBuilder.Entity<Location>()
                .HasData(new List<Location>
                {
                    new()
                    {
                        Id = 1,
                        City = "Tampa",
                        Street = "2547 Nature Walk Drive",
                        PostCode = "33547",
                        MeetupId = 1
                    },
                    new()
                    {
                        Id = 2,
                        City = "Orlando",
                        Street = "1500 International Drive",
                        PostCode = "44547",
                        MeetupId = 2
                    },
                    new()
                    {
                        Id = 3,
                        City = "Atlanta",
                        Street = "235 Presidents Drive",
                        PostCode = "75549",
                        MeetupId = 3
                    },
                    new()
                    {
                        Id = 4,
                        City = "Clearwater",
                        Street = "205 Tampa Drive",
                        PostCode = "33500",
                        MeetupId = 4
                    }
                });

            modelBuilder.Entity<Lecture>()
                .HasData(new List<Lecture>
                {
                    new()
                    {
                        Id = 1,
                        Author = "James",
                        Topic = "C#",
                        Description = "Coding with Visual Studio and C#",
                        MeetupId = 1
                    },
                    new()
                    {
                        Id = 2,
                        Author = "Ben C",
                        Topic = "Algorithms",
                        Description = "Building algorithms with AI and C#",
                        MeetupId = 1
                    },
                    new()
                    {
                        Id = 3,
                        Author = "Peter",
                        Topic = "SSRS with Python",
                        Description = "Creating data mats in open source environments",
                        MeetupId = 2
                    },
                    new()
                    {
                        Id = 4,
                        Author = "Lisa",
                        Topic = "Camping",
                        Description = "Camping site tips for Florida vacationers",
                        MeetupId = 3
                    },
                    new()
                    {
                        Id = 5,
                        Author = "Laura",
                        Topic = "Napa Valley wines",
                        Description = "Guide to Napa Valley wine tours.",
                        MeetupId = 4
                    },
                    new()
                    {
                        Id = 6,
                        Author = "Scott",
                        Topic = "Wine fundamentals",
                        Description = "What is a good wine? Learn how to test and grade wines.",
                        MeetupId = 4
                    }
                });
        }

    }
}

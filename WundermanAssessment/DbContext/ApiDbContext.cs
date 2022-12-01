namespace WundermanAssessment.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Reflection.Metadata;
    using WundermanAssessment.Models;

    namespace EFCoreInMemoryDbDemo
    {
        public class ApiDbContext : DbContext
        {
            public ApiDbContext(DbContextOptions options) : base(options)
            {
                var dataJobs = new List<DataJobDTO>
                {
                new DataJobDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "DataJobTest1",
                    Status = DataJobStatus.New,
                    FilePathToProcess = "FilePathDataJobTest1",
                    Links = new List<Link>
                    {
                        new Link()
                        {
                            Action = "action1",
                            Href = "href1",
                            Rel = "rel1",
                            Types = new List<string>{ "Type1", "Type2"}
                        }

                    },
                    Results = new List<string>()
                    {
                        "Result1"
                    }
                },
                new DataJobDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "DataJobTest2",
                    Status = DataJobStatus.Completed,
                    FilePathToProcess = "FilePathDataJobTest2",
                    Links = new List<Link>
                    {
                        new Link()
                        {
                            Action = "action1",
                            Href = "href1",
                            Rel = "rel1",
                            Types = new List<string>{ "Type1", "Type2"}
                        },
                         new Link()
                        {
                            Action = "action2",
                            Href = "href2",
                            Rel = "rel2",
                            Types = new List<string>{ "Type1"}
                        },
                    },
                    Results = new List<string>()
                    {
                        "Result2", "Result22"
                    }
                },
                new DataJobDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "DataJobTest3",
                    Status = DataJobStatus.Processing,
                    FilePathToProcess = "FilePathDataJobTest3",
                    Links = new List<Link>
                    {
                        new Link()
                        {
                            Action = "action3",
                            Href = "href3",
                            Rel = "rel3",
                            Types =new List<string>{"Type3"}
                        },
                    },
                    Results = new List<string>()
                    {
                        "Result3"
                    }
                }
                };
                DataJobs.AddRange(dataJobs);
                SaveChanges();
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DataJobDTO>()
                    .Property(b => b.Results)
                     .HasConversion(
                        from => string.Join(";", from),
                        to => string.IsNullOrEmpty(to) ? new List<string>() : to.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        new ValueComparer<List<string>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToList()
                        )
                    );                
            }

            public DbSet<DataJobDTO> DataJobs { get; set; }
        }
    }
}

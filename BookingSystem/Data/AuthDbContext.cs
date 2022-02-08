using BookingSystem.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Resource>? Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Data\app.db"));
            var connectionString = builder.ToString();
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Quantity);

                entity.HasData(new List<Resource>()
                {
                new Resource{
                    Id = 1,
                    Name = "Resource1",
                    Quantity = 2
                },
                new Resource{
                    Id = 2,
                    Name = "Resource2",
                    Quantity = 4
                },
                new Resource{
                    Id = 3,
                    Name = "Resource3",
                    Quantity = 6
                },
                new Resource{
                    Id = 4,
                    Name = "Resource4",
                    Quantity = 8
                },
                new Resource{
                    Id = 5,
                    Name = "Resource5",
                    Quantity = 10
                },
                new Resource{
                    Id = 6,
                    Name = "Resource6",
                    Quantity = 12
                }
                });

            });
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BookedQuantity);
                entity.Property(e => e.DateFrom).HasMaxLength(500);
                entity.Property(e => e.DateTo).HasMaxLength(250);
                entity.Property(e => e.ResourceId).IsRequired();

                entity.HasData(new Booking
                {
                    Id = 1,
                    BookedQuantity = 2,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(1),
                    ResourceId = 1
                });

            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressBookEntity> AddressBookEntries { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBookEntity>()
                .ToTable("Users");
                     }
    }
}

using Microsoft.EntityFrameworkCore;
using PhoneBookInfrastructure.Models;

namespace PhoneBookInfrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using guidStore.Data.Models;

namespace guidStore.Data {
    public class GuidDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=guids.db");  //todo: move this to configuration
        }

        public DbSet<GuidModel> guids { get; set; }
    }
}
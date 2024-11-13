using CsvLogParser.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CsvParser.Database
{
    public class CsvLogParserDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
        }
    }
}
using Mango.Services.EmailConsumer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.EmailConsumer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<EmailLogger> EmailLoggers { get; set; }

      
    }
}


using GraphQLExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}

using System.Data.Entity;
using ShiDo.Models;
using ShiDo.Models.Gallery;

namespace ShiDo.DAL
{
    public class ShiDoDbContext : DbContext
    {
        public ShiDoDbContext() : base("Shido_DB")
        {

        }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
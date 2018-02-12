using System.Data.Entity;
using ShiDo.Models.Gallery;

namespace ShiDo.DAL
{
    public class GalleryContext : DbContext
    {
        public GalleryContext() : base("Shido_DB")
        {

        }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
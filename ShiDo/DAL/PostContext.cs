using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShiDo.Models;
using ShiDo.Models.Gallery;

namespace ShiDo.DAL
{
    public class PostContext : DbContext
    {
        public PostContext() : base("Shido_DB")
        {

        }

        public DbSet<Post> Posts { get; set; }

    }
}
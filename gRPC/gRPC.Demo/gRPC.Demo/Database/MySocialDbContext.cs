using gRPC.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC.Demo.Database
{
    public class MySocialDbContext : DbContext
    {
        public MySocialDbContext(DbContextOptions<MySocialDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}

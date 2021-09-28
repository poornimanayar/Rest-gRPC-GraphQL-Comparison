using GraphQL.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GraphQL.Demo.Database
{
    public class MySocialDbContext : DbContext
    {
        public MySocialDbContext(DbContextOptions<MySocialDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(SeedUsers());
            modelBuilder.Entity<Story>().HasData(SeedStory());
            modelBuilder.Entity<Comment>().HasData(SeedComments());
        }

        private static List<User> SeedUsers()
        {
            var jsonString = File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\users.json");

            var users = JsonSerializer.Deserialize<List<User>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return users;
        }

        private static List<Story> SeedStory()
        {
            var jsonString = File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\stories.json");

            var stories = JsonSerializer.Deserialize<List<Story>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return stories;
        }

        private static List<Comment> SeedComments()
        {
            var jsonString = File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\comments.json");

            var comments = JsonSerializer.Deserialize<List<Comment>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return comments;
        }

    }
}

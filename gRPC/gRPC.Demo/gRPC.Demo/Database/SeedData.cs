using gRPC.Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace gRPC.Demo.Database
{
    public class SeedData
    {
        public static void SeedDatabaseWithData(MySocialDbContext _context)
        {
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(SeedUsers());
                _context.SaveChanges();
            }

            if (!_context.Stories.Any())
            {
                _context.Stories.AddRange(SeedStory());
                _context.SaveChanges();
            }

            if (!_context.Comments.Any())
            {
                _context.Comments.AddRange(SeedComments());
                _context.SaveChanges();
            }
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


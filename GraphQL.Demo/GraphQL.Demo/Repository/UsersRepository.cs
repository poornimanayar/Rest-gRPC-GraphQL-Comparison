using GraphQL.Demo.Database;
using GraphQL.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.Repository
{
    public class UsersRepository : IAsyncDisposable
    {
        private readonly MySocialDbContext _context;

        public UsersRepository(IDbContextFactory<MySocialDbContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool CheckUserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public int UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            var updated = _context.SaveChanges();
            return updated;
        }

        public int DeleteUser(User user)
        {
            _context.Users.Remove(user);
           var deleted = _context.SaveChanges();
            return deleted;
        }

    }
}

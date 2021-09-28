using Microsoft.EntityFrameworkCore;
using REST.Demo.Database;
using REST.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Repository
{
    public class UsersRepository
    {

        private readonly MySocialDbContext _context;

        public UsersRepository(MySocialDbContext context)
        {
            _context = context;
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

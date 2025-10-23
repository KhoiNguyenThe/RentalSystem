using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepository
    {
        private readonly EvsdbContext _db;

        public enum RegisterResult
        {
            Success,
            EmailExists,
            UsernameExists,
            Failed
        }

        public UserRepository()
        {
            _db = new EvsdbContext();
        }

        public User? Login(string email, string password)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsEmailExists(string email)
        {
            return _db.Users.Any(u => u.Email == email);
        }

        public bool IsNameExists(string fullName)
        {
            return _db.Users.Any(u => u.FullName == fullName);
        }

        public bool AddUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveCitizenImage(string email, string filePath)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                var citizen = new CitizenId
                {
                    UserId = user.Id,
                    ImageUrl = filePath
                };
                _db.CitizenIds.Add(citizen);
                _db.SaveChanges();
            }
        }
    }
}

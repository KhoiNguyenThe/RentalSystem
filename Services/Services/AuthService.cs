using Repositories.Entities;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Repositories.UserRepository;

namespace Services.Services
{
    public class AuthService
    {
        private readonly UserRepository _repo;

        public AuthService()
        {
            _repo = new UserRepository();
        }

        public User? Login(string email, string password)
        {
            return _repo.Login(email, password);
        }

        public RegisterResult Register(string fullName, string email, string password, string? citizenImagePath)
        {
            if (_repo.IsEmailExists(email))
                return RegisterResult.EmailExists;

            if (_repo.IsNameExists(fullName))
                return RegisterResult.UsernameExists;

            var user = new User
            {
                FullName = fullName,
                Email = email,
                Password = password,
                Role = "customer",
                IsActive = true
            };

            bool added = _repo.AddUser(user);

            if (added && !string.IsNullOrEmpty(citizenImagePath))
            {
                _repo.SaveCitizenImage(user.Email, citizenImagePath);
            }

            return added ? RegisterResult.Success : RegisterResult.Failed;
        }
    }
}

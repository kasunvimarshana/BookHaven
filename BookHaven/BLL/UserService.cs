using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class UserService
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public List<User> GetAllUsers() => _userRepo.GetAllUsers();

        public User? GetUserById(int id) => _userRepo.GetUserById(id);

        public bool CreateUser(User user)
            => _userRepo.CreateUser(user);

        public bool UpdateUser(User user) 
            => _userRepo.UpdateUser(user);

        public bool DeleteUser(int id) => _userRepo.DeleteUser(id);
    }
}


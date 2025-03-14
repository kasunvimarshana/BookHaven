using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class UserService
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public List<User> GetAllUsers() => _userRepo.GetAllUsers();

        public User? GetUserById(int id) => _userRepo.GetUserById(id);

        public bool CreateUser(User user, SqlTransaction transaction = null)
            => _userRepo.CreateUser(user, transaction);

        public bool UpdateUser(User user, SqlTransaction transaction = null) 
            => _userRepo.UpdateUser(user, transaction);

        public bool DeleteUser(int id, SqlTransaction transaction = null) => _userRepo.DeleteUser(id, transaction);
    }
}


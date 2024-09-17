using BusinessObjects.Models;
using DataAccess.DAO;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        public User FindUserByEmailAndPassword(string Email, string plainPassword) => UserDAO.FindUserByEmailAndPassword(Email, plainPassword);
    }
}

using BusinessObjects;
using BusinessObjects.Models;
using DataAccessObject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        public static User? FindUserByEmailAndPassword(string email, string plainPassword)
        {
            PasswordHasher hasher = new PasswordHasher();
            try
            {
                var hashedPassword = hasher.HashPassword(plainPassword);

                using (var context = new ApplicationDBContext())
                {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    bool UserIsDeleted = context.Users.FirstOrDefault(u => u.Email == email).IsDeleted == 0;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                    if (UserIsDeleted) { return null; }

                    var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == hashedPassword);

                    if (user != null) return user;
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

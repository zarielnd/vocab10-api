using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Services
{
    internal class PasswordHasher
    {
        public string HashPassword(string plainPassword)
        {
            // Implement your hashing logic here. For example, using SHA256:
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plainPassword);
                var hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes); // Store as Base64 or Hex string
            }
        }
    }
}

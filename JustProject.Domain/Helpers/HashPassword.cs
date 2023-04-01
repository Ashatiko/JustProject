using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Helpers
{
    public class HashPassword
    {
        public static string HashPasswordHelper(string password)
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                byte[] hash = SHA256.ComputeHash(bytes);

                string result = Convert.ToBase64String(hash);
                return result;
            }
        }
    }
}

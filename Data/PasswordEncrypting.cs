using AdaCredit.UI.Domain;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace AdaCredit.UI.Data
{
    public class PasswordEncrypting
    {

        public static string GenerateSalt()
        {
            return new Faker().Random.Replace("$2a$10$***********************");
        }
        
        public static string GenerateHash(string cleanPassword, out string salt)
        {
            salt = GenerateSalt();
            var hashedPassword = HashPassword(cleanPassword, salt, false);

            return hashedPassword;
        }

        public static string Hash(string cleanPassword, string salt)
        {
            var hashedPassword = HashPassword(cleanPassword, salt, false);

            return hashedPassword;
        }
    }
}

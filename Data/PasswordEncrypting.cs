﻿using AdaCredit.UI.Domain;
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
        
        public static string Encrypt(string cleanPassword, string salt)
        {
            var hashedPassword = HashPassword(cleanPassword, salt, false);

            return hashedPassword;
        }
    }
}

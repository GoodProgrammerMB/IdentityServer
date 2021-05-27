﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GP.IdentityServer.Helpers
{
    public static class PasswordHelper
    {
        private static Random random = new Random();

        public static string GenerateRandomPassword(int length = 8)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateSalt()
        {
            var data = new byte[0x10];

            RandomNumberGenerator.Create().GetBytes(data);

            return Convert.ToBase64String(data);
        }

        public static string HashPassword(string password, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(password);
            var src = Convert.FromBase64String(salt);
            var dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            var algorithm = SHA1.Create();
            var inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }
    }
}

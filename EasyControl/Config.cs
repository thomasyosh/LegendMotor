using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyControl
{
    internal class Config
    {
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Source\Repos\EasyControl\EasyControl\easycontrol.mdf;Integrated Security=True;MultipleActiveResultSets=True;";

        public static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}

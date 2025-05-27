using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetierRvMedical.Helper
{
    public static class CryptString
    {
        public static string GetMd5Hash(string input)
        {

            StringBuilder sBuilder = new StringBuilder();
            // Implement your encryption logic here
            // For demonstration, we'll just reverse the string
            using (MD5 md5hash = MD5.Create())
            {
                byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            return sBuilder.ToString();
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input
            string hashOfInput = GetMd5Hash(input);
            // Create a StringComparer an compare the hashes
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

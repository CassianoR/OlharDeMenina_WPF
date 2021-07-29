using System;
using System.Security.Cryptography;
using System.Text;

namespace LojaOlharDeMenina_WPF.Core
{
    public class Hash
    {
        public Hash()
        {
        }

        public string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
    }
}
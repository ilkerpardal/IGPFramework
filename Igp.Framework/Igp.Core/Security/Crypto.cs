using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Igp.Core.Security
{
    public class Crypto : ICrypto
    {
        public string Md5Hashing(string key)
        {
            MD5 md5Format = new MD5CryptoServiceProvider();
            md5Format.ComputeHash(Encoding.ASCII.GetBytes(key));
            byte[] result = md5Format.Hash;
            StringBuilder builder = new StringBuilder();
            result.ToList().ForEach(item => builder.Append(item.ToString("x2")));
            return builder.ToString();
        }
    }
}

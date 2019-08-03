using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igp.Core.Security
{
    public interface ICrypto
    {
        string Md5Hashing(string key);
    }
}

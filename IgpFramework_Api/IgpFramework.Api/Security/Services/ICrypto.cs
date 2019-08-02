using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgpFramework.Api.Security.Services
{
    public interface ICrypto
    {
        string Md5Hashing(string key);
    }
}

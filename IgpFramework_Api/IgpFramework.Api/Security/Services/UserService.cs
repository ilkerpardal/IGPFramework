using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IgpFramework.Api.Model;
using IgpFramework.Api.Security.Token;
using IgpFramework.Data;
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IgpFramework.Api.Helpers;
using AutoMapper;

namespace IgpFramework.Api.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IGPCoreContext _context;
        private readonly TokenManagement _tokenManagement;
        private readonly ICrypto _crypto;

        public UserService(IGPCoreContext context, IOptions<TokenManagement> tokenManagement, ICrypto crypto)
        {
            _context = context;
            _tokenManagement = tokenManagement.Value;
            _crypto = crypto;
        }

        public UserDto Authenticate(string userName, string password)
        {
            var passwordHash = _crypto.Md5Hashing(password);
            var user = _context.User.FirstOrDefault(x => x.UserName == userName);
            if (user.IsAssigned())
            {
                if (user.Password == passwordHash) {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = SignHandler.GetSecurityKey("vwaXxKAsTQ5msMfiYNYdzd4KBpjR5Y4MIGP");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("userName",user.UserName),
                            new Claim("userId",user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        Audience = "mysite.com",
                        Issuer = "mysite.com",
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var userDto= user.GetMap<UserDto>();
                    userDto.Token = tokenHandler.WriteToken(token);
                    return userDto;
                }
                else
                {
                    throw new Exception("Password error");//ToDo: Mesajlara taşınacak 
                }
            }
            else {
                throw new Exception("User not found");//ToDo: Mesajlara taşınacak 
            }

            //return _context.User.FirstOrDefault(user => user.KullaniciAdi == userName && user.Sifresi == passwordHash);
            
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users= _context.User.AsEnumerable();
            return users.GetMap<IEnumerable<UserDto>>();
        }        
    }
}

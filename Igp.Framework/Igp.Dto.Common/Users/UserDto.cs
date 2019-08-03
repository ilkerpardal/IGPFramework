using IgpFramework.Dto.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgpFramework.Dto.Common.Users
{
    public class UserDto : TableBaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? IdentityKey { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Sex { get; set; }
        public string Token { get; set; }
    }
}

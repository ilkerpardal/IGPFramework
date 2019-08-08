using Igp.Dto.Common.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Igp.Dto.Common.Users
{
    [DataContract]
    public class UserDto : TableBaseDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public decimal? IdentityKey { get; set; }

        [DataMember]
        public DateTime? Birthdate { get; set; }

        [DataMember]
        public int? Sex { get; set; }

        [DataMember]
        public string Token { get; set; }


        public virtual ICollection<UserPasswordDto> UserPasswords { get; set; }

        [DataMember]
        public virtual ICollection<UserMenuDto> UserMenuPermissions { get; set; }
        public virtual ICollection<UserSessionDto> UserSessions { get; set; }

        [DataMember]
        public virtual ICollection<UserTransactionDto> UserTransactions { get; set; }
    }
}

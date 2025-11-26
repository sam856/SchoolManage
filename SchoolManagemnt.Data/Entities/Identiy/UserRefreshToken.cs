using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Entities.Identiy
{
    public  class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsExpired { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public string? JWTId { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        [InverseProperty("RefreshTokens")]
        [ForeignKey(nameof(UserId))]

        public virtual User? User { get; set; }

    }
}

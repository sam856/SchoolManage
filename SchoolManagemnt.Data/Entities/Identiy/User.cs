using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities.Identiy
{
    public class User : IdentityUser<int>, IUpdatedBase, ICreatedBase
    {
        public User()
        {
            RefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string FullName { get; set; }


        [InverseProperty("User")]
        public ICollection<UserRefreshToken> RefreshTokens { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}

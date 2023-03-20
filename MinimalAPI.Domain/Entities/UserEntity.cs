using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Domain.Entities
{
    public class UserEntity : IdentityUser
    {

        [Column("FLG_IS_DELETED")]
        public bool isDeleted { get; set; } = false;
        [Column("DAT_CREATED_AT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("DAT_UPDATED_AT")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserInfoEntity UserInfoEntity { get; set; }
        
    }
}

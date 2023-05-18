using Microsoft.AspNetCore.Identity;

namespace AnimeFuns.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Roles? Role { get; set; }
        public IdentityUser? User { get; set; }
        
    }
}

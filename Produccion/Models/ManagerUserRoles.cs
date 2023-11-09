using Microsoft.AspNetCore.Identity;

namespace Producciones.Models
{
    public class ManagerUserRoles
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool Selected { get; set; }
    }
}

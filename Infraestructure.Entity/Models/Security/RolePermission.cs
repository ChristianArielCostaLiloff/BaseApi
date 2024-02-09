using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models.Security
{
    [Table("RolePermissions", Schema = "Security")]
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public Role Role { get; set; } = null!;

        [ForeignKey("Permission")]
        public int IdPermission { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}

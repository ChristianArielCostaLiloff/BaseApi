using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models.Security
{
    [Table("Permissions", Schema = "Security")]
    public class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Description { get; set; } = null!;

        public IEnumerable<RolePermission> RolePermissions { get; set; }
    }
}

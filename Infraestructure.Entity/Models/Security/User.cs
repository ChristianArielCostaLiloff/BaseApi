using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models.Security
{
    [Table("Users", Schema = "Security")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public Role RoleEntity { get; set; } = null!;
    }
}

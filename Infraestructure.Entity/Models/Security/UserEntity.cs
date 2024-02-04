using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models.Security
{
    [Table("User", Schema = "Security")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = null!;

        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public RoleEntity RoleEntity { get; set; } = null!;
    }
}

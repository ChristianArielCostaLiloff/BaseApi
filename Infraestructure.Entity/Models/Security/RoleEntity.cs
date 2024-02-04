using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models.Security
{
    [Table("Role", Schema = "Security")]
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
    }
}

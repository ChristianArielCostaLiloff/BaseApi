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
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(128)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("Role")]
        public int IdRole { get; set; }
        public Role Role { get; set; } = null!;
    }
}

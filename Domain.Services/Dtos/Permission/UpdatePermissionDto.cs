using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Dtos.Permission
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Permission Id is required.")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Permission name is required.")]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Permission description is required.")]
        [MaxLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
    }
}

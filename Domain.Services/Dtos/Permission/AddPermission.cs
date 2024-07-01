using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Dtos.Permission
{
    public class AddPermission
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
    }
}

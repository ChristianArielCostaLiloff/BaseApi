using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Dtos.User
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "User ID is required for the update.")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Description is required for the update.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Role ID is required for the update.")]
        public int IdRole { get; set; }
    }
}

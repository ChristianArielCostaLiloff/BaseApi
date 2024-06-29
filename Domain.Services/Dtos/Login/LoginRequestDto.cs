using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Dtos.Login
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "User name required.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; } = null!;
    }
}

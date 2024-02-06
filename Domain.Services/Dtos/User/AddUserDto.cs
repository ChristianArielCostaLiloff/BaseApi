using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Dtos.User
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "IdRole is required.")]
        [Display(Name = "IdRole")]
        public int IdRole { get; set; }
    }
}

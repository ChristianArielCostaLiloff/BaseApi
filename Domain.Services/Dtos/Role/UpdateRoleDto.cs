using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Dtos.Role
{
    public class UpdateRoleDto
    {
        [Required(ErrorMessage = "Role ID is required for the update.")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required for the update.")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}

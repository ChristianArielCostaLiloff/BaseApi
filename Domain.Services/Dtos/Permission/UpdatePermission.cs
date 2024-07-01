﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Dtos.Permission
{
    public class UpdatePermission
    {
        [Required(ErrorMessage = "Id is required.")]
        [Display(Name = "Id")]
        public int Id { get; set; }

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

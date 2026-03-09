using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class CreateProjDTO
    {
        [Required]
        public string projectName { get; set; } = string.Empty;
        public string? projectDescription { get; set; } = string.Empty;
    }
}

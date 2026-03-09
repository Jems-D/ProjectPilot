using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DTO;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Mappers
{
    public static class ProjectMappers
    {
        public static Project ToProjFromCreateDTO(this CreateProjDTO dto)
        {
            return new Project
            {
                ProjectName = dto.projectName,
                Description = dto.projectDescription,
            };
        }
    }
}

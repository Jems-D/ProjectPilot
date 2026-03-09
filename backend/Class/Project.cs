using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("Project")]
    public class Project
    {
        [Column("ProjectId")]
        [Key]
        public Guid ProjectId { get; set; } = new Guid();

        [Column("ProjectName")]
        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string ProjectName { get; set; }

        [Column("ProjectDescription")]
        [MinLength(20)]
        public string? Description { get; set; } = string.Empty;

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column("StatusId")]
        [Range(0, 3)]
        public int StatusId { get; set; } = 0;
        public ProjectTasks? ProjectTasks { get; set; }

        [ForeignKey(nameof(StatusId))]
        public TaskOrProjectStatus? TaskOrProjectStatus { get; set; }
    }
}

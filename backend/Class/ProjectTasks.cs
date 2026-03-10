using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("ProjectTasks")]
    public class ProjectTasks
    {
        [Column("ProjectTasksId")]
        [Key]
        public Guid ProjectTaskId { get; set; } = new Guid();

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column("ProjectTaskDescription")]
        public string? ProjectTaskDescription { get; set; } = string.Empty;

        [Column("ProjectTaskName")]
        public string? ProjectTaskName { get; set; } = string.Empty;
        public Guid ProjectId { get; set; }
        public int StatusId { get; set; } = 0;

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        [ForeignKey(nameof(StatusId))]
        public TaskOrProjectStatus TaskOrProjectStatus { get; set; }
    }
}

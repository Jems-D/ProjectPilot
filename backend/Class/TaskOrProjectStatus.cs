using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("TaskOrProjectStatus")]
    public class TaskOrProjectStatus
    {
        [Column("Id")]
        [Range(0, 3)]
        [Key]
        public int StatusId { get; set; }

        [Column("StatusName")]
        [Required]
        public string StatusName { get; set; } = string.Empty;
    }
}

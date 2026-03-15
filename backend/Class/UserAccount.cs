using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Column("UserAccount", TypeName = "UNIQUEIDENTIFIER")]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [Column("Required")]
        public string Email { get; set; } = string.Empty;

        [Column("IsVerified")]
        public bool IsVerified { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}

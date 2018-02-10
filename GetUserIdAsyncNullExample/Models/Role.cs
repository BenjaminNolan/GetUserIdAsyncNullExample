using Microsoft.AspNetCore.Identity;
using GetUserIdAsyncNullExample.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetUserIdAsyncNullExample.Models
{
    public class Role : IdentityRole<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("NEWSEQUENTIALID()")]
        new public Guid Id { get; set; }
    }
}

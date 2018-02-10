using GetUserIdAsyncNullExample.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetUserIdAsyncNullExample.Models
{
    [Serializable]
    public class User : IdentityUser<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("NEWSEQUENTIALID()")]
        new public Guid Id { get; set; }

        public string DisplayName { get; set; } = null;

        public string GivenName { get; set; } = null;

        public string FamilyName { get; set; } = null;
    }
}

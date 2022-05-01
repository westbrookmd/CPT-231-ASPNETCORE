using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace M12Assignment.Models
{
    public class User : IdentityUser
    {

        [NotMapped]
        public IList<string> RoleNames { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationId { get; set; }

        public String Name { get; set; }

        public virtual ICollection<Scope> Scopes { get; set; }

    }
}
